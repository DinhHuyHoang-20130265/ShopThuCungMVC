using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThuCungMVC.Models
{
   
    public class ShoppingCartViewModel
    {
        public String productID { get; set; }
        public Product product { get; set; }
        public int quantityCart { get; set; }
        public ShoppingCartViewModel(string productID, Product product, int quantityCart)
        {
            this.productID = productID;
            this.product = product;
            this.quantityCart = quantityCart;
        }
    }

}
