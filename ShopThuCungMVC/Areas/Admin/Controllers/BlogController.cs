using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult AddBlog()
        {
            return View();
        }
    }
}
