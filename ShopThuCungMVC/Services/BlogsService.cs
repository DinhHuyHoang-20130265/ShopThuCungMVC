using ShopThuCungMVC.DAO;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
namespace ShopThuCungMVC.Services
{
    public class BlogsService
    {
        public static List<Blog> listBlog()
        {
            return BlogsDAO.listBlog();
        }

        public static Blog BlogById(string id)
        {
            return BlogsDAO.BlogById(id);
        }

        public static List<Blog> get3BlogNew()
        {
            return BlogsDAO.get3BlogNew();
        }


    }
}