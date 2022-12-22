﻿using Microsoft.Extensions.Logging;
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
        [HttpGet]
        public ActionResult AllProduct()
        {
            List<Product> listProductById = ProductCateService.listProductbyCate(null).ToList();
            return View(listProductById);
        }
        [HttpPost]
        public ActionResult AllProduct(String Id)
        {
            List<Product> listProductById = ProductCateService.listProductbyCate(Id).ToList();
            return View(listProductById);
        }
        public JsonResult LoadMoreProduct(string id, int page)
        {
            if (id.Equals("AllProduct"))
            {
                List<Product> listProductById = ProductCateService.listProductbyCate(null).Skip(page * 6).Take(6).ToList();
                return Json(new { data = listProductById }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Product> listProductById = ProductCateService.listProductbyCate(id).Skip(page * 6).Take(6).ToList();
                return Json( new { data = listProductById }, JsonRequestBehavior.AllowGet);
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
    }
}