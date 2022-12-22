using ShopThuCungMVC.Models;
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
            return Json(new { id, quantity = quantity1 }, JsonRequestBehavior.AllowGet);
        }
    }
}