using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }
    }
}
