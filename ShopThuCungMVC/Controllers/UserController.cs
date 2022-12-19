using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account != null)
                return RedirectToAction("Index", "Admin");
            else
            {
                UserAccount cus = AccountService.loginSite(username, password);
                if (cus != null)
                {
                    Session["user"] = cus;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View();
                }
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon(); // xoa session
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public ActionResult Register()
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassWord()
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Register(string name, string birthday, string gender, string email, string phone, string username, string password)
        {
            if (AccountService.checkEmailExist(email)) {
                return Json(new {status = "Email đã được sử dụng" }, JsonRequestBehavior.AllowGet);
            }
            if (AccountService.checkUsernameExist(username))
            {
                return Json(new { status = "Tài khoản đã được sử dụng" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["code"] = "123456";
                return Json(new { check = true }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Verify(string code)
        {
            string codecomfirm = (string) Session["code"];
            if (code.Equals(codecomfirm))
            {
                Session["registerSuccess"] = "Chúc mừng bạn đã đăng ký thành công, mời bạn đăng nhập";
                return Json(new { success = true });
            }
            else 
                return Json(new { success = false });
        }
    }
}