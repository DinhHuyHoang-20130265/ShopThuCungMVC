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
<<<<<<< HEAD

=======
>>>>>>> 93e37e9fd386e73b6fcb4f753603c8e5333b55bc

        public static Product Detail(String id)
        {
            return ProductCategoryDAO.Detail(id);
<<<<<<< HEAD
        }

        public static List<Product> Filter(string order_by, String cate_id
            , String price, String size, String search)
        {
            return ProductCategoryDAO.Filter( order_by,  cate_id
            ,  price,  size,  search);
=======
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
>>>>>>> 93e37e9fd386e73b6fcb4f753603c8e5333b55bc
        }
    }
}