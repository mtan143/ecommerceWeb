using EcommerceWeb.DAL;
using EcommerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace EcommerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        private ApplicationDbContext applicationDbContext = new ApplicationDbContext();
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
            if (Session["Cart"] == null)
                return RedirectToAction("NullCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult NullCart()
        {
            return View();
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

        public ActionResult CreateOrder()
        {
            Cart cart = Session["Cart"] as Cart;
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = applicationDbContext.Users.First(x => x.Id == currentUserId);
            var hoaDon = new HoaDon
            {
                KhachHangID = db.KhachHangs.First(x => x.Username == currentUser.Email).KhachHangID,
                Ngay = DateTime.Now,
                MatHangs = new List<ChiTietHoaDon>(),
                TrangThai = 0
            };
            foreach (var item in cart.Items)
            {
                var cthd = new ChiTietHoaDon
                {
                    HoaDonID = hoaDon.HoaDonID,
                    MatHangID = item.shoppingProduct.MatHangID,
                    SoLuong = item.shoppingQuantity,
                    ThanhTien = item.shoppingProduct.DonGia * item.shoppingQuantity
            };
                db.ChiTietHoaDons.Add(cthd);
                hoaDon.MatHangs.Add(cthd);
                hoaDon.TongTien = cart.TotalPrice();
                db.HoaDons.Add(hoaDon);
            }
            int result = db.SaveChanges();

            if (result > 0)
            {
                cart.RemoveAll();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Payment", "ShoppingCart");
            //cart.RemoveAll();
            //return RedirectToAction("Index", "Home");
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

        public ActionResult BagCart()
        {
            int tongMH = 0;
            Cart cart = (Session["Cart"] as Cart) ?? new Cart();
            if(cart != null)
            {
                tongMH = cart.TotalQuantity();
            }
            ViewBag.infoCart = tongMH;
            return PartialView("BagCart");
        }
    }
}