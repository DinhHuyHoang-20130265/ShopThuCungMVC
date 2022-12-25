using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class Blog
    {
        private int v1;
        private string v2;
        private object value1;
        private object value2;
        private object value3;
        private string userid;
        private object value4;

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

        public Blog(string blogId, string blogName, int v1, string v2, object value1, object value2, object value3, string userid, object value4)
        {
            BlogId = blogId;
            BlogName = blogName;
            this.v1 = v1;
            this.v2 = v2;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.userid = userid;
            this.value4 = value4;
        }
    }
}