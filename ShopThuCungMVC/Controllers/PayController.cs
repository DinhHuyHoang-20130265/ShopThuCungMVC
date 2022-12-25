using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
    public class PayController : Controller
    {
        [HttpGet]
        public ActionResult Pay()
        {
            UserAccount account = (UserAccount)Session["user"];
            if (User != null)
                return View();
            else return RedirectToAction("User", "Login");
        }
        [HttpPost]
        public ActionResult Pay(string name, string address, string phone, string email, string notice)
        {
            UserAccount account = (UserAccount)Session["user"];
            if (account != null)
            {
                OrderService.AddNewOrders(account.id, (ShoppingCart)Session["cart"]);

                Session["cart"] = new ShoppingCart();
                return RedirectToAction("Cart", "ProductBag");
            }    
            else 
                return RedirectToAction("User", "Login");
        }
    }
}
