using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceWeb.DAL;
using EcommerceWeb.Models;

namespace EcommerceWeb.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: ChiTietHoaDon
        public ActionResult Index()
        {
            var chiTietHoaDons = db.ChiTietHoaDons.Include(c => c.HoaDon).Include(c => c.MatHang);
            return View(chiTietHoaDons.ToList());
        }

        // GET: ChiTietHoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDon/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID");
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH");
            return View();
        }

        // POST: ChiTietHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChiTietHoaDonID,MatHangID,HoaDonID,SoLuong,ThanhTien")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chiTietHoaDon.HoaDonID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", chiTietHoaDon.MatHangID);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chiTietHoaDon.HoaDonID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", chiTietHoaDon.MatHangID);
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChiTietHoaDonID,MatHangID,HoaDonID,SoLuong,ThanhTien")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chiTietHoaDon.HoaDonID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", chiTietHoaDon.MatHangID);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chiTietHoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
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
