using ShopThuCungMVC.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopThuCungMVC.Models;

namespace ShopThuCungMVC.Services
{
    public class ProductCateService
    {
        public static List<ProductCategory> listProductCate()
        {
            return ProductCategoryDAO.listProductCate();

        }

        public static List<Product> listProductbyCate(String id)
        {
            return ProductCategoryDAO.listProductbyCate(id);
        }
    }
}