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
        public ActionResult AddToCart(string id, int quantity)
        {
            var code = new { Success=false, msg="", code=-1 };
            var db = new ShopThuCungDBContext();
            var checkProduct = db.product.FirstOrDefault(x => x.productId == id);
            if(checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart(null);
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductID = (string)checkProduct.productId,
                    //ProductIMG = checkProduct.Image,
                    ProductName = checkProduct.ProductName,
                    ProductPrice = checkProduct.Price,
                    Quantity = quantity,
                    //TotalPrice = checkProduct.Quantity * checkProduct.Price
                    
                };
                item.ProductPrice = checkProduct.Price;
                item.TotalPrice = item.Quantity * item.ProductPrice;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = -1 };
            }
            return Json(code);
        }
    }
}