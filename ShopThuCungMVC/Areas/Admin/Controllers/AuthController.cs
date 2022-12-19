using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Admin");

        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.error = "Phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(password))
            {
                ViewBag.error = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (admin)
                UserAccount admin = AccountService.loginAdmin(username, password);
                if (admin != null)
                {
                    Session["admin"] = admin;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon(); // xoa session
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public ActionResult ForgotPassWord()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        public ActionResult ForgotPassWord(string email)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return RedirectToAction("Index", "Admin");
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
        public ActionResult VerifyCode(string code)
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
        public ActionResult ChangePassWord(string pass)
        {
            AccountService.UpdateUser(MD5.CreateMD5(pass), pass, null, (string)Session["email"], null, null, null);
            Session["changepass"] = "Chúc mừng bạn đã đổi mật khẩu thành công, mời bạn đăng nhập";
            return RedirectToAction("Login", "Auth");
        }
    }
}
