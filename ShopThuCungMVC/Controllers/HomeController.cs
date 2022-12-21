using Microsoft.Extensions.Logging;
using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
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
        [HttpGet]
        public ActionResult AllProduct()
        {
            List<Product> listProductById = ProductCateService.listProductbyCate(null);
            return View(listProductById);
        }
        [HttpPost]
        public ActionResult AllProduct(String Id)
        {
            List<Product> listProductById = ProductCateService.listProductbyCate(Id);
            return View(listProductById);
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