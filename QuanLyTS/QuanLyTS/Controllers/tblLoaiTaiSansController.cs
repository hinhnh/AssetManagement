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
    public class tblLoaiTaiSansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblLoaiTaiSans
        public ActionResult Index()
        {
            return View(db.tblLoaiTaiSans.ToList());
        }

        // GET: tblLoaiTaiSans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLoaiTaiSan tblLoaiTaiSan = db.tblLoaiTaiSans.Find(id);
            if (tblLoaiTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblLoaiTaiSan);
        }

        // GET: tblLoaiTaiSans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblLoaiTaiSans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] tblLoaiTaiSan tblLoaiTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.tblLoaiTaiSans.Add(tblLoaiTaiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLoaiTaiSan);
        }

        // GET: tblLoaiTaiSans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLoaiTaiSan tblLoaiTaiSan = db.tblLoaiTaiSans.Find(id);
            if (tblLoaiTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblLoaiTaiSan);
        }

        // POST: tblLoaiTaiSans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] tblLoaiTaiSan tblLoaiTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLoaiTaiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLoaiTaiSan);
        }

        // GET: tblLoaiTaiSans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLoaiTaiSan tblLoaiTaiSan = db.tblLoaiTaiSans.Find(id);
            if (tblLoaiTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblLoaiTaiSan);
        }

        // POST: tblLoaiTaiSans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblLoaiTaiSan tblLoaiTaiSan = db.tblLoaiTaiSans.Find(id);
            db.tblLoaiTaiSans.Remove(tblLoaiTaiSan);
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
