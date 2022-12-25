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
            List<Blog> listBlogById = BlogsService.getBlog();
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View(listBlogById);
            else
                return RedirectToAction("Login", "Auth");
        }
        public void UploadFile(HttpPostedFileBase file)
        {
            try
            {
                string _path = null;
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        _path = Path.Combine(Server.MapPath("~/Content/img/blog"), _FileName);
                        file.SaveAs(_path);
                    }
                }
            }
            catch
            {
            }
        }
        [HttpGet]
        public ActionResult AddBlog(string bid)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (bid != null)
                {
                    Blog blog = BlogsService.DetailBlog(bid);
                    return View(blog);
                }
                else
                {
                    return View();
                }
            }
            else
                return RedirectToAction("Login", "Auth");
        }
        [HttpPost]
        public ActionResult AddBlog(string blogid, string userid, string blogname, string desc, HttpPostedFileBase file)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (blogid != null)
                {
                    UploadFile(file);
                    string _FileName = "";
                    if (file != null)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                    }
                    BlogsService.UpdateBlog(blogid, userid, blogname, _FileName, desc);
                    return RedirectToAction("Blogs", "Admin/Blog");
                }
                else
                {
                    UploadFile(file);
                    string _FileName = "";
                    if (file != null)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                    }
                    BlogsService.AddNewBlog(userid, blogname, _FileName, desc);
                    return RedirectToAction("Blogs", "Admin/Blog");
                }
            }
            else
                return RedirectToAction("Login", "Auth");
        }

        public ActionResult DeleteBlog(string bid)
        {
            if (bid != null)
            {
                BlogsService.DeleteBlog(bid);
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }

    }
}