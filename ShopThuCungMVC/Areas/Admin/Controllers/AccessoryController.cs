using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class AccessoryController : Controller
    {
        public ActionResult Accessories()
        {
            List<Product> listProductById = ProductCateService.listProductAccessorybyCate(null);
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
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        _path = Path.Combine(Server.MapPath("~/Content/img/products"), _FileName);
                        file.SaveAs(_path);
                    }
                }
            }
            catch
            {
            }
        }
        [HttpGet]
        public ActionResult AddAccessory(String pid)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (pid != null)
                {
                    Product product = ProductCateService.Detail(pid);
                    return View(product);
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
        public ActionResult AddAccessory(string productid, string userid, string productname, string desc, HttpPostedFileBase file, string price, string promoPrice, string quantity, string date, string giong, string size)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                if (productid != null)
                {
                    UploadFile(file);
                    string _FileName = "";
                    if (file != null)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                    }
                    ProductCateService.UpdateAccessory(productid, userid, productname, _FileName, desc, price, promoPrice, quantity, date, giong, size);
                    return RedirectToAction("Accessories", "Admin/Accessory");
                }
                else
                {
                    UploadFile(file);
                    string _FileName = "";
                    if (file != null)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                    }
                    ProductCateService.AddNewAccessory(userid, productname, _FileName, desc, price, promoPrice, quantity, date, giong, size);
                    return RedirectToAction("Accessories", "Admin/Accessory");
                }
            }
            else
                return RedirectToAction("Login", "Auth");
        }
        public ActionResult DeleteProduct(string pid)
        {
            if (pid != null)
            {
                ProductCateService.DeleteProduct(pid);
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}
