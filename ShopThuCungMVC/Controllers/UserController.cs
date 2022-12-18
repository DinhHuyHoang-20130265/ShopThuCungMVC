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
        public ActionResult Login(String username, String password)
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (String.IsNullOrEmpty(username))
            {
                ViewData["username"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(username))
            {
                ViewData["password"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (user)
                UserAccount cus = AccountService.loginSite(username, password);
                if (cus != null)
                {
                    ViewBag.Notify = "Chúc mừng đăng nhập thành công";
                    Session["user"] = cus;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Login", "User");
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
                string html =
                        "<form method=\"POST\">\r\n                        " +
                        "<div class=\"row row-space\">\r\n                            " +
                        "<div class=\"col-2\">\r\n                               " +
                        " <div class=\"input-group\">\r\n                                  " +
                        "  <label class=\"label\">Nhập mã xác thực email</label>\r\n" +
                        "<input class=\"input--style-4\" type=\"text\" name=\"code\" id=\"code\" required>\r\n" +
                        "</div>\r\n                            " +
                        "</div>\r\n                        " +
                        "</div>" +
                        "<div class=\"p-t-15\">\r\n\r\n" +
                        "<a><div class=\"btn btn--radius-2 btn--blue\" id=\"verifyCode\">Xác thực</div></a>" +
                        "</div>" +
                        "</form>";
                return Json(new { html }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Verify(String code)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}