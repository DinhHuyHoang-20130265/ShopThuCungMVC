using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThuCungMVC.Models
{

    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart(List<ShoppingCartItem> Items)
        { 
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int QuantityCart)
        {
            var checkExist = Items.FirstOrDefault(x => x.ProductID == item.ProductID);
            if (checkExist != null)
            {
                checkExist.Quantity += QuantityCart;
                checkExist.TotalPrice = checkExist.ProductPrice * checkExist.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(string id)
        {
            var checkExist = Items.SingleOrDefault(x => x.ProductID == id);
            if (checkExist != null)
            {
                Items.Remove(checkExist);
            }
        }

        public void UpdateQuantityCart(string id, int quantity)
        {
            var checkExist = Items.SingleOrDefault(x => x.ProductID == id);
            if (checkExist != null)
            {
                checkExist.Quantity = quantity;
                checkExist.TotalPrice = checkExist.ProductPrice * checkExist.Quantity;
            }
        }

        public Double GetTotalPrice()
        {
            return Items.Sum(x=>x.TotalPrice);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }
        public class ShoppingCartItem
        {

            public string ProductID { get; set; }
            public string ProductIMG { get; set; }
            public string ProductName { get; set; } 
            public double ProductPrice { get; set; }
            public int Quantity { get; set; }
            public double TotalPrice { get; set; }

            //public ShoppingCartViewModel(string productID, string productName, double productPrice, int quantity, double totalPrice)
            //{
            //    ProductID = productID;
            //    ProductName = productName;
            //    ProductPrice = productPrice;
            //    Quantity = quantity;
            //    TotalPrice = totalPrice;
            //}
        }
    }

}
