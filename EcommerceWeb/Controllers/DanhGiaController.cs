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
    public class DanhGiaController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: DanhGias
        public ActionResult Index()
        {
            var danhGias = db.DanhGias.Include(d => d.KhachHang).Include(d => d.MatHang);
            return View(danhGias.ToList());
        }

        // GET: DanhGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // GET: DanhGias/Create
        public ActionResult Create()
        {
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH");
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH");
            return View();
        }

        // POST: DanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoiDung,Sao,KhachHangID,MatHangID")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                danhGia.ThoiGian = DateTime.Now;
                danhGia.LanCuoiChinhSua = DateTime.Now;
                db.DanhGias.Add(danhGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", danhGia.KhachHangID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", danhGia.MatHangID);
            return View(danhGia);
        }

        // GET: DanhGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", danhGia.KhachHangID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", danhGia.MatHangID);
            return View(danhGia);
        }

        // POST: DanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoiDung,Sao,LanCuoiChinhSua,KhachHangID,MatHangID")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                danhGia.LanCuoiChinhSua = DateTime.Now;
                db.Entry(danhGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHangID = new SelectList(db.KhachHangs, "KhachHangID", "TenKH", danhGia.KhachHangID);
            ViewBag.MatHangID = new SelectList(db.MatHangs, "MatHangID", "TenMH", danhGia.MatHangID);
            return View(danhGia);
        }

        // GET: DanhGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // POST: DanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            db.DanhGias.Remove(danhGia);
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
        
        public int totalDanhGiaByProductId(int productId)
        {
            if (productId.Equals(null))
            {
                return 0;
            }
            return db.DanhGias.Where(cmt => cmt.MatHangID.Equals(productId)).ToList().Count;
        }

        public List<DanhGia> getDanhGiaByUserId(int userId)
        {
            if (userId.Equals(null))
            {
                return new List<DanhGia>();
            }
            return db.DanhGias.Where(cmt => cmt.MatHangID.Equals(userId)).ToList();
        }
    }
}
