﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
    }
}
