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
            return View();
        }
        public ActionResult AddAccessory()
        {
            return View();
        }
    }
}
