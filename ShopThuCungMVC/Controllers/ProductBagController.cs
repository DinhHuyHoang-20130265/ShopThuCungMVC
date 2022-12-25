using ShopThuCungMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
    public class ProductBagController : Controller
    {         
        public ActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(string id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.Put(id, quantity);
            Session["cart"] = cart;
            int quantity1 = cart.getQuantityCart();
            return Json(new { id, quantity = quantity1, total = cart.Total()}, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult RemoveProduct(string id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.Remove(id);
            Session["cart"] = cart;
            return Json(new { total = cart.Total() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QuantityCart(int quantity, string id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.getData()[id] = quantity;
            Session["cart"] = cart;
            return Json(new { total = cart.Total(), sumId = cart.Sum(id, quantity), quantityleft = cart.getQuantityCart()}, JsonRequestBehavior.AllowGet);
        }
    }
}