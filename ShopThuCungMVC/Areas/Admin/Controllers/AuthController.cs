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
        public ActionResult Login(String username, String password)
        {
            UserAccount account = (UserAccount)Session["admin"];
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
                //Gán giá trị cho đối tượng được tạo mới (admin)
                UserAccount admin = AccountService.loginAdmin(username, password);
                if (admin != null)
                {
                    ViewBag.Notify = "Chúc mừng đăng nhập thành công";
                    Session["admin"] = admin;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult LogOut()
        {
            Session.Abandon(); // xoa session
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult ForgotPassWord()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account == null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }
    }
}
