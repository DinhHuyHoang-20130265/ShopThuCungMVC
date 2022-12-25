using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }
        public ActionResult Admins()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public ActionResult AddAdmin(string username, string email, string address, string fullname, string passwd, string passwdconfirm, string phone, string status)
        {
            int statuss = 1;
            if (status.Equals("Khóa"))
            {
                statuss = 0;
            }
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (AccountService.checkEmailExist(email))
                {
                    Session["errorAddAdmin"] = "Email đã tồn tại!";
                    return View();
                }
                else
                {
                    if (AccountService.checkUsernameExist(username))
                    {
                        Session["errorAddAdmin"] = "Tên tài Khoản đã tồn tại!";
                        return View();
                    }
                    else
                    {
                        if (passwd.Equals(passwdconfirm))
                        {
                            AccountService.addAdmin(username, email, address, fullname, passwd, phone, statuss);
                            return RedirectToAction("Admins", "Admin");
                        }
                        else
                        {
                            ViewBag.PassError = "Mật khẩu nhập lại không đúng!";
                            return View();
                        }
                    }
                }


            }
            else
                return RedirectToAction("Login", "Auth");
        }

        public ActionResult Remove(string id)
        {
            AccountService.removeAccount(id);
            return RedirectToAction("Admins", "Admin");
        }
    }
    
}
