using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ShopThuCungMVC.Models.ShoppingCart;

namespace ShopThuCungMVC.Controllers
{
    public class ProductBagController : Controller
    {         
        public ActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Put(string id, int quantity)
        {
           return Json(new { id, quantity });
        }
    }
}