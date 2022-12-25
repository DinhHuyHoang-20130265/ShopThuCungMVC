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
        public ActionResult AddAccessory()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }
        [HttpPost]
        public ActionResult AddAccessory(string userid, string productname, string desc, HttpPostedFileBase file, string price, string promoPrice, string quantity, string date, string giong, string size)
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
            {
                UploadFile(file);
                string _FileName = Path.GetFileName(file.FileName);
                ProductCateService.AddNewAccessory(userid, productname, _FileName, desc, price, promoPrice, quantity, date, giong, size);
                return RedirectToAction("Accessories", "Admin/Accessory");
            }
            else
                return RedirectToAction("Login", "Auth");
        }
    }
}
