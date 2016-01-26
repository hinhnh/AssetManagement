using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTS.Models;

namespace QuanLyTS.Controllers
{
    public class tblTaiKhoansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblTaiKhoans
        public ActionResult Index()
        {
            var tblTaiKhoans = db.tblTaiKhoans.Include(t => t.tblCanBoGiaoVien);
            return View(tblTaiKhoans.ToList());
        }

        // GET: tblTaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiKhoan tblTaiKhoan = db.tblTaiKhoans.Find(id);
            if (tblTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(tblTaiKhoan);
        }

        // GET: tblTaiKhoans/Create
        public ActionResult Create()
        {
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen");
            return View();
        }

        // POST: tblTaiKhoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDangNhap,MatKhau,MaGiaoVien,Quyen,NgayDangKy")] tblTaiKhoan tblTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.tblTaiKhoans.Add(tblTaiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblTaiKhoan.MaGiaoVien);
            return View(tblTaiKhoan);
        }

        // GET: tblTaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiKhoan tblTaiKhoan = db.tblTaiKhoans.Find(id);
            if (tblTaiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblTaiKhoan.MaGiaoVien);
            return View(tblTaiKhoan);
        }

        // POST: tblTaiKhoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDangNhap,MatKhau,MaGiaoVien,Quyen,NgayDangKy")] tblTaiKhoan tblTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTaiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblTaiKhoan.MaGiaoVien);
            return View(tblTaiKhoan);
        }

        // GET: tblTaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiKhoan tblTaiKhoan = db.tblTaiKhoans.Find(id);
            if (tblTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(tblTaiKhoan);
        }

        // POST: tblTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblTaiKhoan tblTaiKhoan = db.tblTaiKhoans.Find(id);
            db.tblTaiKhoans.Remove(tblTaiKhoan);
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
