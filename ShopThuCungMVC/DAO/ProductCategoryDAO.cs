using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.DAO
{
    public class ProductCategoryDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static List<ProductCategory> listProductCate()
        {
            return db.product_category.ToList();
        }

        public static List<Product> listProductbyCate(String id)
        {
            List<Product> list = null;
            List<ProductFromCate> listPdCat= db.product_from_cate.Where(a => a.cate_id == id).ToList();
            foreach (var item in listPdCat)
            {
                list = db.product.Where(n => n.productId == item.product_id).ToList();
            }
            return list;
        }
    }
}