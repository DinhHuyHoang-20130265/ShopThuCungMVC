using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class Blog
    {
        public string BlogId { get; set; }
        public string BlogName { get; set;}
        public int Status { get; set;}
        public string Image { get; set;}
        public string Desription { get; set;}
        public string Dital { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }

        public Blog(string blogId, string blogName, int status, string image, string desription, string Dital, string createBy, string createDate, string updateBy, string updateDate)
        {
            BlogId = blogId;
            BlogName = blogName;
            Status = status;
            Image = image;
            Desription = desription;
            this.Dital = Dital;
            CreateBy = createBy;
            CreateDate = createDate;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }
    }
}