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
    public class LoaiHangController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: LoaiHang
        public ActionResult Index()
        {
            return View(db.LoaiHangs.ToList());
        }

        // GET: LoaiHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // GET: LoaiHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiID,TenLoai")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(loaiHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHang);
        }

        // GET: LoaiHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // POST: LoaiHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiID,TenLoai")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHang);
        }

        // GET: LoaiHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // POST: LoaiHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            db.LoaiHangs.Remove(loaiHang);
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


        public ActionResult Man()
        {
            var manProduct = db.MatHangs.Where(x => x.Gender == 1).ToList();
            return View(manProduct);
        }

        public ActionResult Woman()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 0).ToList();
            return View(womanProduct);
        }



        public ActionResult ManTS()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 1 && x.LoaiID == 1).ToList();
            return View(womanProduct);
        }
        public ActionResult ManS()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 1 && x.LoaiID == 2).ToList();
            return View(womanProduct);
        }
        public ActionResult ManPS()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 1 && x.LoaiID == 3).ToList();
            return View(womanProduct);
        }
        public ActionResult WomanD()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 0 && x.LoaiID == 4).ToList();
            return View(womanProduct);
        }
        public ActionResult WomanTS()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 0 && x.LoaiID == 5).ToList();
            return View(womanProduct);
        }
        public ActionResult WomanT()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 0 && x.LoaiID == 6).ToList();
            return View(womanProduct);
        }
    }
}
