using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThuCungMVC.Controllers
{
	public class DetailsController : Controller
	{
		public ActionResult BlogDetails()
		{
			return View();
		}
		public ActionResult ProductDetails(String id)
		{
			Product detail = Services.ProductCateService.Detail(id);
			return View(detail);
		}
	}
}
