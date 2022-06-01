using EcommerceWeb.DAL;
using EcommerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;    
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart (int id)
        {
            var mathang = db.MatHangs.SingleOrDefault(x => x.MatHangID == id);
            if(mathang != null)
            {
                GetCart().Add(mathang);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult ShowToCart()
        {
            //if (Session["Cart"] == null)
            //    return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult UpdateQuantityInCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int IDMatHang = int.Parse(form["ID_MatHang"]);
            int soluongMH = int.Parse(form["SoLuong_MH"]);
            cart.UpdateQuantityProductCart(IDMatHang, soluongMH);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult RemoveProductInCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveProduct(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        [Authorize]
        public ActionResult Payment()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return View(cart);
        }

        public PartialViewResult BagCart()
        {
            int tongMH = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            {
                tongMH = cart.TotalQuantity();
            }
            ViewBag.infoCart = tongMH;
            return PartialView("BagCart");
        }
    }
}