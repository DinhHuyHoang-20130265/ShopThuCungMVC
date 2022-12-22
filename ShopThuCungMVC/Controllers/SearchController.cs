using ShopThuCungMVC.Models;
using ShopThuCungMVC.Services;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ShopThuCungMVC.Controllers
{
    public class SearchController : Controller
    {
        public JsonResult GetAllProd(string txtSearch)
        {
            List<Product> list = ProductCateService.searchByName(txtSearch);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}
