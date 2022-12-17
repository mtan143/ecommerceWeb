using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class CartItem
    {
        public MatHang shoppingProduct { get; set; }
        public int shoppingQuantity { get; set; }
    }
    public class Cart
    {
        static Cart instance;

        private static object locker = new object();
        public static Cart GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Cart();
                    }
                }
            }
            return instance;
        }


        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items;  }
        }
        public void Add(MatHang mathang, int soluong = 1)
        {
            var item = items.FirstOrDefault(x => x.shoppingProduct.MatHangID == mathang.MatHangID);
            if(item == null)
            {
                items.Add(new CartItem
                {
                    shoppingProduct = mathang,
                    shoppingQuantity = soluong,
                });
            }
            else
            {
                item.shoppingQuantity += soluong;
            }
        }

        public void UpdateQuantityProductCart(int id, int soluong)
        {
            var item = items.Find(x => x.shoppingProduct.MatHangID == id);
            if(item != null)
            {
                item.shoppingQuantity = soluong; 
            }
        }

        public int TotalPrice()
        {
            var total = items.Sum(x => x.shoppingProduct.DonGia * x.shoppingQuantity);
            return total;
        }

        public void RemoveProduct(int id)
        {
            items.RemoveAll(x => x.shoppingProduct.MatHangID == id);
        }

        public int TotalQuantity()
        {
            return items.Sum(x => x.shoppingQuantity);
        }

        public void RemoveAll()
        {
            items.Clear();
        }
    }
}