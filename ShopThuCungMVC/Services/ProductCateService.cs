using ShopThuCungMVC.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopThuCungMVC.Models;
using System.Threading.Tasks;

namespace ShopThuCungMVC.Services
{
    public static class ProductCateService
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
        public static List<Product> Filter(String id, String price,String size, String orderby)
        {
            return ProductCategoryDAO.Filter(id,price,size,orderby);
        }

        internal static void AddNewProduct(string userid, string productname, string _FileName, string desc, string price, string promoPrice, string quantity, string cannang, string mausac, string date, string giong, string size)
        {
            ProductCategoryDAO.AddNewProduct(userid, productname, _FileName, desc, price, promoPrice, quantity, cannang, mausac, date, giong, size);
        }
        internal static void AddNewAccessory(string userid, string productname, string _FileName, string desc, string price, string promoPrice, string quantity, string date, string giong, string size)
        {
            ProductCategoryDAO.AddNewAccessory(userid, productname, _FileName, desc, price, promoPrice, quantity, date, giong, size);
        }

        public static void DeleteProduct(string id)
        {
            ProductCategoryDAO.DeleteProduct(id);
        }

        internal static void UpdateProduct(string pid, string userid, string productname, string fileName, string desc, string price, string promoPrice, string quantity, string cannang, string mausac, string date, string giong, string size)
        {
            ProductCategoryDAO.UpdateProduct(pid, userid, productname, fileName, desc, price, promoPrice, quantity, cannang, mausac, date, giong, size);
        }
        internal static void UpdateAccessory(string pid, string userid, string productname, string fileName, string desc, string price, string promoPrice, string quantity, string date, string giong, string size)
        {
            ProductCategoryDAO.UpdateAccessory(pid, userid, productname, fileName, desc, price, promoPrice, quantity, date, giong, size);
        }
        public static List<ProductCategory> listProCateClassify(String id)
        {
            return ProductCategoryDAO.listProCateClassify(id);
        }
    }
}