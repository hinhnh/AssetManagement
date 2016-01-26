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
    public class tblCanBoGiaoViensController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblCanBoGiaoViens
        public ActionResult Index()
        {
            var tblCanBoGiaoViens = db.tblCanBoGiaoViens.Include(t => t.tblBoPhan);
            return View(tblCanBoGiaoViens.ToList());
        }

        // GET: tblCanBoGiaoViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCanBoGiaoVien tblCanBoGiaoVien = db.tblCanBoGiaoViens.Find(id);
            if (tblCanBoGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(tblCanBoGiaoVien);
        }

        // GET: tblCanBoGiaoViens/Create
        public ActionResult Create()
        {
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan");
            return View();
        }

        // POST: tblCanBoGiaoViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiaoVien,HoTen,EMail,SoDienThoai,MaBoPhan,QueQuan,NgaySinh,GioiTinh,TrinhDo,ChucVu,ChuyenMon")] tblCanBoGiaoVien tblCanBoGiaoVien)
        {
            if (ModelState.IsValid)
            {
                db.tblCanBoGiaoViens.Add(tblCanBoGiaoVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "MaDonVi", tblCanBoGiaoVien.MaBoPhan);
            return View(tblCanBoGiaoVien);
        }

        // GET: tblCanBoGiaoViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCanBoGiaoVien tblCanBoGiaoVien = db.tblCanBoGiaoViens.Find(id);
            if (tblCanBoGiaoVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblCanBoGiaoVien.MaBoPhan);
            return View(tblCanBoGiaoVien);
        }

        // POST: tblCanBoGiaoViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiaoVien,HoTen,EMail,SoDienThoai,MaBoPhan,QueQuan,NgaySinh,GioiTinh,TrinhDo,ChucVu,ChuyenMon")] tblCanBoGiaoVien tblCanBoGiaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCanBoGiaoVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblCanBoGiaoVien.MaBoPhan);
            return View(tblCanBoGiaoVien);
        }

        // GET: tblCanBoGiaoViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCanBoGiaoVien tblCanBoGiaoVien = db.tblCanBoGiaoViens.Find(id);
            if (tblCanBoGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(tblCanBoGiaoVien);
        }

        // POST: tblCanBoGiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblCanBoGiaoVien tblCanBoGiaoVien = db.tblCanBoGiaoViens.Find(id);
            db.tblCanBoGiaoViens.Remove(tblCanBoGiaoVien);
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
