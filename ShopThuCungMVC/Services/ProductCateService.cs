using ShopThuCungMVC.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopThuCungMVC.Models;
using System.Threading.Tasks;

namespace ShopThuCungMVC.Services
{
    public class ProductCateService
    {
        public static List<ProductCategory> listProductCate()
        {
            return ProductCategoryDAO.listProductCate();
        }

        public static List<Product> listAllProduct()
        {
            return ProductCategoryDAO.listAllProduct();
        }
        public static List<Product> listProductbyCate(String id)
        {
            return ProductCategoryDAO.listProductbyCate(id);
        }

        public static Product Detail(String id)
        {
            return ProductCategoryDAO.Detail(id);
        }
        
        public static List<Product> searchByName(String txt)
        {
            return ProductCategoryDAO.searchByName(txt);
        }
        
        public static List<Product> listProductDogAndCatbyCate(String id)
        {
            return ProductCategoryDAO.listProductDogAndCatbyCate(id);
        }
        
        public static List<Product> listProductAccessorybyCate(String id)
        {
            return ProductCategoryDAO.listProductAccessorybyCate(id);
        }

        public static List<Product> getTop8BestSelling()
        {
            return ProductCategoryDAO.getTop8BestSelling();
        }
        public static List<Blog> get3Blog()
        {
            return ProductCategoryDAO.get3Blog();
        }
        public static List<Product> Filter(String id, String price,String size)
        {
            return ProductCategoryDAO.Filter(id,price,size);
        }
    }
}