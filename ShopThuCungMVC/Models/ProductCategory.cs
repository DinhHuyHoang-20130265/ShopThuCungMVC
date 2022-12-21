using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class ProductCategory
    {
        [Key]
        public string CatId { get; set; }
        public string CatName { get; set; }
        public int Status { get; set; }
        public int Sort { get; set; }

        public string ParentID { get; set; }

        public string CreateBy { get; set; }

        public string CreateDate { get; set; }
        public string UpdateBy { get ; set ; }

        public string UpdateDate { get; set; }

        public ProductCategory(string CatId, string CatName, int Status, int Sort, string ParentID, string CreateBy, string CreateDate, string UpdateBy, string UpdateDate)
        {
            this.CatId = CatId;
            this.CatName = CatName;
            this.Status = Status;
            this.Sort = Sort;
            this.ParentID = ParentID;
            this.CreateBy = CreateBy;
            this.CreateDate = CreateDate;
            this.UpdateBy = UpdateBy;
            this.UpdateDate = UpdateDate;
        }


    }
}