using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

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
                    Session["cart"] = new ShoppingCart();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Notify = "Tên đăng nhập, mật khẩu không đúng hoặc tài khoản của bạn đã bị vô hiệu hóa";
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
        [HttpGet]
        public ActionResult ForgotPassWord()
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult ForgotPassWord(string email)
        {
            if (AccountService.checkEmailExist(email))
            {
               if (!AccountService.checkStatusEmailAccount(email))
                {
                    return Json(new { status = "Tài khoản này đã bị vô hiệu hóa" }, JsonRequestBehavior.AllowGet);
                }
               else
                {
                    DateTime nowDate = new DateTime();
                    DateTime timeExistsTypeDate = new DateTime(nowDate.Millisecond + 3 * 60);
                    Session["timeExists"] = timeExistsTypeDate.Millisecond;
                    string code = GenerateVerifyCode.GenerateNewRandom();
                    Session["email"] = email;
                    Session["code"] = code;
                    MailService.SendMailForForgotPassword(code, email);
                    return Json(new { check = true }, JsonRequestBehavior.AllowGet);
                }
            } 
            else
            {
                return Json(new { status = "Email không tồn tại" }, JsonRequestBehavior.AllowGet);
            }
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
                DateTime nowDate = new DateTime();
                DateTime timeExistsTypeDate = new DateTime(nowDate.Millisecond + 3*60);
                Session["timeExists"] = timeExistsTypeDate.Millisecond;
                string code = GenerateVerifyCode.GenerateNewRandom();
                Session["code"] = code;
                RegisterModel registerModel = new RegisterModel(username, password, name, email, phone, gender, birthday);
                MailService.SendMailForSignUp(code, email);
                Session["registerModel"] = registerModel;
                return Json(new { check = true }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Verify(string code)
        {
            string codecomfirm = (string) Session["code"];
            if ((int)Session["timeExists"] >= new DateTime().Millisecond)
            {
                if (code.Equals(codecomfirm))
                {
                    AccountService.InsertUser((RegisterModel) Session["registerModel"]);
                    Session["registerSuccess"] = "Chúc mừng bạn đã đăng ký thành công, mời bạn đăng nhập";
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            } else
            {
                return Json(new { timeout = true });
            }
            
        }
        [HttpPost]
        public ActionResult VerifyForgot(String code)
        {
            string codecomfirm = (string)Session["code"];
            if ((int)Session["timeExists"] >= new DateTime().Millisecond)
            {
                if (code.Equals(codecomfirm))
                {
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            }
            else
            {
                return Json(new { timeout = true });
            }
        }
        [HttpPost]
        public ActionResult ChangePassWord(string pass) {
            AccountService.UpdateUser(MD5.CreateMD5(pass), pass, null, (string)Session["email"], null, null, null);
            Session["registerSuccess"] = "Chúc mừng bạn đã đổi mật khẩu thành công, mời bạn đăng nhập";
            return RedirectToAction("Login", "User");
        }

        public ActionResult InforUser()
        {
            return View();
        }

    }
}