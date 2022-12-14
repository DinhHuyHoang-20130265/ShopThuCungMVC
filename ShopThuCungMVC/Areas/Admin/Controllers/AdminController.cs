using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public ActionResult AddAdmin(string aid)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (aid != null)
                {
                    UserAccount admin = AccountService.getAdminById(aid);
                    return View(admin);
                }
                else
                {
                    return View();
                }
            }
            else
                return RedirectToAction("Login", "Auth");
        }
        public ActionResult InfoAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(string userid, string username, string email, string address, string fullname, string passwd, string passwdconfirm, string phone, string status)
        {
            UserAccount admin = AccountService.getAdminById(userid);
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (userid != null)
                {

                    if (passwd.Equals(passwdconfirm))
                    {
                        AccountService.UpdateAdmin(userid, username, email, address, fullname, passwd, phone, int.Parse(status));
                        return RedirectToAction("Admins", "Admin");
                    }
                    else
                    {
                        ViewBag.PassError = "Mật khẩu nhập lại không đúng!";
                        return View(admin);
                    }


                }
                else
                {
                    if (AccountService.checkEmailExist(email))
                    {
                        ViewBag.errorAddAdmin = "Email đã tồn tại!";
                        return View();
                    }
                    else
                    {
                        if (AccountService.checkUsernameExist(username))
                        {
                            ViewBag.errorAddAdmin = "Tên tài Khoản đã tồn tại!";
                            return View();
                        }
                        else
                        {
                            if (passwd.Equals(passwdconfirm))
                            {
                                AccountService.addAdmin(username, email, address, fullname, passwd, phone, int.Parse(status));
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
