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
        ShopThuCungDBContext data = new ShopThuCungDBContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
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
                AccountService accountsv = new AccountService();
                CustomerUser cus = accountsv.login(username, password);
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
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassWord()
        {
            return View();
        }
    }
}