using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using PagedList;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceWeb.DAL;
using EcommerceWeb.Models;
using System.IO;

namespace EcommerceWeb.Controllers
{
    public class MatHangController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: MatHang
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(m => m.LoaiHang);

            return View(matHangs.ToList());
        }

        // GET: MatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }

            var commentList = db.DanhGias.Where(cmt => cmt.MatHangID == id).ToList();

            var tupleResult = new Tuple<MatHang, List<DanhGia>>(matHang, commentList);
             
            return View(tupleResult);
        }

        // GET: MatHang/Create
        public ActionResult Create()
        {
            ViewBag.LoaiID = new SelectList(db.LoaiHangs, "LoaiID", "TenLoai");
            return View();
        }

        // POST: MatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "MatHangID,TenMH,DonGia,MoTa,LoaiID,NSX,HSD,TongSoLuong")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                var ext = Path.GetExtension(file.FileName);

                if (allowedExtensions.Contains(ext)) //check what type of extension
                {
                    var path = Path.Combine(Server.MapPath("~/image"), Path.GetFileName(file.FileName));
                    var imgLink = "~/image/" + file.FileName;
                    matHang.HinhAnh = imgLink;
                    matHang.SoLuongTonKho = matHang.TongSoLuong;
                    db.MatHangs.Add(matHang);
                    ViewBag.FileStatus = "File uploaded successfully.";
                    db.SaveChanges();
                    file.SaveAs(path);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Please choose only Image file";
                }
            }

            ViewBag.LoaiID = new SelectList(db.LoaiHangs, "LoaiID", "TenLoai", matHang.LoaiID);
            return View(matHang);
        }


        // GET: MatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiID = new SelectList(db.LoaiHangs, "LoaiID", "TenLoai", matHang.LoaiID);
            return View(matHang);
        }

        // POST: MatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatHangID,TenMH,DonGia,MoTa,Size,Color,Gender,LoaiID,HinhAnh")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiID = new SelectList(db.LoaiHangs, "LoaiID", "TenLoai", matHang.LoaiID);
            return View(matHang);
        }

        // GET: MatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: MatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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
