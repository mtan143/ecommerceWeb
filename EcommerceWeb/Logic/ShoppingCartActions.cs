using EcommerceWeb.DAL;
using EcommerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        private EcommerceContext _db = new EcommerceContext();

        public const string CartSessionKey = "CartId";
        public void AddToCart(int id)
        {
            ShoppingCartId = GetCartId();

            var cartItem = _db.CartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId && c.MatHangId == id);

            if (cartItem == null)
            {
                cartItem = new Models.CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    MatHangId = id,
                    CartId = ShoppingCartId,
                    MatHang = _db.MatHangs.SingleOrDefault(
                        p => p.Id == id),
                    DateCreated = DateTime.Now
                };
                _db.CartItems.Add(cartItem);
            } else
            {
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }


        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.CartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
    }
}