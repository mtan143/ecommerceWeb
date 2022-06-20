using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EcommerceWeb.DAL;
using EcommerceWeb.Models;

namespace EcommerceWeb.Controllers
{
    public class HoaDonController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang);
            return View(hoaDons.ToList());
        }

        // GET: HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH");
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoaDonID,KhachHangID,Ngay,TongTien,TrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", hoaDon.KhachHangID);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", hoaDon.KhachHangID);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoaDonID,KhachHangID,Ngay,TongTien,TrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", hoaDon.KhachHangID);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OrderUser(int KhachHangID)
        {
            var list = db.HoaDons.Where(x => x.KhachHangID == KhachHangID).ToList();
            return View(list);
        }

        public ActionResult Cancel(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            hoaDon.TrangThai = 4;
            db.SaveChanges();
            return RedirectToAction("OrderUser", "HoaDon", new { KhachHangID = hoaDon.KhachHangID});
        }

        public ActionResult UpdateOrder(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon.TrangThai == 0) { hoaDon.TrangThai = 1; }
            else if (hoaDon.TrangThai == 1) { hoaDon.TrangThai = 2; }
            else if (hoaDon.TrangThai == 2) { hoaDon.TrangThai = 3; }
            else if (hoaDon.TrangThai == 4) { hoaDon.TrangThai = 5; }
            else { hoaDon.TrangThai = 6; }
            db.SaveChanges();
            return RedirectToAction("Index", "HoaDon");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
