using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
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
		public ActionResult ProductDetails(String id)
		{
			if (string.IsNullOrEmpty(id))
			{
                return RedirectToAction("AllProduct", "Home");
            }
			Product detail = Services.ProductCateService.Detail(id);
			return View(detail);
		}
	}
}
