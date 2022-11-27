using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
    public class ProductBagController : Controller
    {
        public ActionResult ListLike()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
    }
}