using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Utilities;
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
        public ActionResult AllProduct(String Id)
        {
            if (Id == null)
            {
                List<Product> listProductById = ProductCateService.listAllProduct();
                return View(listProductById);
            }
            else
            {
                List<Product> listProductById = ProductCateService.listProductbyCate(Id);
                return View(listProductById);
            }
        }
        public JsonResult LoadMoreProduct(string id, int page, String price, String size, String orderby)
        {
            if (id.Equals("AllProduct"))
            {
                List<Product> listProductById = ProductCateService.Filter(price, id, size, orderby).Skip(page * 6).Take(6).ToList();
                return Json(new { data = listProductById }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Product> listProductById = ProductCateService.Filter(price, id, size, orderby).Skip(page * 6).Take(6).ToList();
                return Json(new { data = listProductById }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }
        public JsonResult Filter(String price, String category, String size, String orderby)
        {
            List<Product> list = ProductCateService.Filter(price, category, size, orderby);
            return Json(new { data = list, count = list.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listCate(String category)
        {
            return View();
        }
        public ActionResult listProCateClassify(String id)
        {
            return View();
        }
    }
}