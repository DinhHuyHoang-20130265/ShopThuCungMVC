using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Blogs()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public ActionResult AddBlog(string userid, string name, string desc, HttpPostedFileBase file)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                UploadFile(file);
                string _FileName = Path.GetFileName(file.FileName);
                BlogCateService.AddBlog(userid, name, _FileName, desc);
                return RedirectToAction("Blog", "Admin/Blog");
            }
            else
                return RedirectToAction("Login", "Auth");
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            try
            {
                string _path = null;
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    _path = Path.Combine(Server.MapPath("~/Content/img/products"), _FileName);
                    file.SaveAs(_path);
                }
            }
            catch
            {
            }
        }


    }
}
