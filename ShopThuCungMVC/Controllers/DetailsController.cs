using Antlr.Runtime.Misc;
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
       /* public ActionResult ProductDetails()*/
		{
			Product detail = Services.ProductCateService.Detail(id);
			return View(detail);
		}

		public ActionResult Filter(string order_by, String cate_id
			, String price, String size, String search)
		{
			List<Product> filter = ProductCateService.Filter(order_by, cate_id, price, size, search);
			return View(filter);
		}
    }
}
