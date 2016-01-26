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
    public class tblKhoTaiSansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblKhoTaiSans
        public ActionResult Index()
        {
            var tblKhoTaiSans = db.tblKhoTaiSans.Include(t => t.tblKhoLuuTru).Include(t => t.tblTaiSan);
            return View(tblKhoTaiSans.ToList());
        }

        // GET: tblKhoTaiSans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoTaiSan tblKhoTaiSan = db.tblKhoTaiSans.Find(id);
            if (tblKhoTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblKhoTaiSan);
        }

        // GET: tblKhoTaiSans/Create
        public ActionResult Create()
        {
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai");
            return View();
        }

        // POST: tblKhoTaiSans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKho,MaTaiSan,SoLuong")] tblKhoTaiSan tblKhoTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.tblKhoTaiSans.Add(tblKhoTaiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblKhoTaiSan.MaKho);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblKhoTaiSan.MaTaiSan);
            return View(tblKhoTaiSan);
        }

        // GET: tblKhoTaiSans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoTaiSan tblKhoTaiSan = db.tblKhoTaiSans.Find(id);
            if (tblKhoTaiSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblKhoTaiSan.MaKho);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblKhoTaiSan.MaTaiSan);
            return View(tblKhoTaiSan);
        }

        // POST: tblKhoTaiSans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKho,MaTaiSan,SoLuong")] tblKhoTaiSan tblKhoTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKhoTaiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblKhoTaiSan.MaKho);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblKhoTaiSan.MaTaiSan);
            return View(tblKhoTaiSan);
        }

        // GET: tblKhoTaiSans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoTaiSan tblKhoTaiSan = db.tblKhoTaiSans.Find(id);
            if (tblKhoTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblKhoTaiSan);
        }

        // POST: tblKhoTaiSans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblKhoTaiSan tblKhoTaiSan = db.tblKhoTaiSans.Find(id);
            db.tblKhoTaiSans.Remove(tblKhoTaiSan);
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
