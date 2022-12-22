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