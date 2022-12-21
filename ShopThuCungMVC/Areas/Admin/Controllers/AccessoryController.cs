using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult AddAccessory()
        {
            UserAccount account = (UserAccount)Session["admin"];
            if (account != null)
                return View();
            else
                return RedirectToAction("Login", "Auth");
        }
    }
}
