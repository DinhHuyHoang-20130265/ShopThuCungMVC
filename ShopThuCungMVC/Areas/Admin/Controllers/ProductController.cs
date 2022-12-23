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
    public class ProductController : Controller
    {
        public ActionResult Products()
        {
            List<Product> listProductById = ProductCateService.listProductDogAndCatbyCate(null);
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View(listProductById);
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
        [HttpGet]
        public ActionResult AddProduct()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }
        [HttpPost]
        public ActionResult AddProduct(string userid, string productname, string desc, HttpPostedFileBase file, string price, string promoPrice, string quantity, string cannang, string mausac, DateTime date, string giong, string size) 
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                UploadFile(file);
                ProductCateService.AddNewProduct(userid, productname, desc, price, promoPrice, quantity, cannang, mausac, date, giong, size);
            }
            else
                return RedirectToAction("Login", "Auth");
            return null;
        }
    }
}