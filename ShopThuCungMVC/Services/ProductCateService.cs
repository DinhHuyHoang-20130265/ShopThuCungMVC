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


        public static Product Detail(String id)
        {
            return ProductCategoryDAO.Detail(id);
        }

        public static List<Product> Filter(string order_by, String cate_id
            , String price, String size, String search)
        {
            return ProductCategoryDAO.Filter( order_by,  cate_id
            ,  price,  size,  search);
        }
    }
}