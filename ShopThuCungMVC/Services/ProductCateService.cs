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
<<<<<<< HEAD

        public static Product Detail(String id)
        {
            return ProductCategoryDAO.Detail(id);
=======
        public static List<Product> listProductDogAndCatbyCate(String id)
        {
            return ProductCategoryDAO.listProductDogAndCatbyCate(id);
        }
        public static List<Product> listProductAccessorybyCate(String id)
        {
            return ProductCategoryDAO.listProductAccessorybyCate(id);
>>>>>>> 22498d4ff4045973f642c72c024d5c5b80f26fb0
        }
    }
}