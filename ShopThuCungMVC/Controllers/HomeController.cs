using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult AllProduct()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }
    }
}