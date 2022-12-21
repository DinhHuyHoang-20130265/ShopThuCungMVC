using ShopThuCungMVC.Models;
<<<<<<< HEAD
=======
using ShopThuCungMVC.Services;
>>>>>>> 0f01d35cf128b8dbbb4828ebde0e3213c3bedb9c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
	public class DetailsController : Controller
	{
		public ActionResult BlogDetails(string id)
		{
			if (id == null)
			{
                return RedirectToAction("Blog", "Home");
            }
            Blog blog = BlogsService.BlogById(id);
            return View(blog);
		}
<<<<<<< HEAD
		public ActionResult ProductDetails(String id)
=======
        public ActionResult ProductDetails()
>>>>>>> 0f01d35cf128b8dbbb4828ebde0e3213c3bedb9c
		{
			Product detail = Services.ProductCateService.Detail(id);
			return View(detail);
		}
	}
}
