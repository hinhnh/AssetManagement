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
    public class tblKhoLuuTrusController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblKhoLuuTrus
        public ActionResult Index()
        {
            var tblKhoLuuTrus = db.tblKhoLuuTrus.Include(t => t.tblBoPhan);
            return View(tblKhoLuuTrus.ToList());
        }

        // GET: tblKhoLuuTrus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoLuuTru tblKhoLuuTru = db.tblKhoLuuTrus.Find(id);
            if (tblKhoLuuTru == null)
            {
                return HttpNotFound();
            }
            return View(tblKhoLuuTru);
        }

        // GET: tblKhoLuuTrus/Create
        public ActionResult Create()
        {
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan");
            return View();
        }

        // POST: tblKhoLuuTrus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKho,TenKho,MaBoPhan,GhiChu")] tblKhoLuuTru tblKhoLuuTru)
        {
            if (ModelState.IsValid)
            {
                db.tblKhoLuuTrus.Add(tblKhoLuuTru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "MaDonVi", tblKhoLuuTru.MaBoPhan);
            return View(tblKhoLuuTru);
        }

        // GET: tblKhoLuuTrus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoLuuTru tblKhoLuuTru = db.tblKhoLuuTrus.Find(id);
            if (tblKhoLuuTru == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblKhoLuuTru.MaBoPhan);
            return View(tblKhoLuuTru);
        }

        // POST: tblKhoLuuTrus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKho,TenKho,MaBoPhan,GhiChu")] tblKhoLuuTru tblKhoLuuTru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKhoLuuTru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblKhoLuuTru.MaBoPhan);
            return View(tblKhoLuuTru);
        }

        // GET: tblKhoLuuTrus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhoLuuTru tblKhoLuuTru = db.tblKhoLuuTrus.Find(id);
            if (tblKhoLuuTru == null)
            {
                return HttpNotFound();
            }
            return View(tblKhoLuuTru);
        }

        // POST: tblKhoLuuTrus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblKhoLuuTru tblKhoLuuTru = db.tblKhoLuuTrus.Find(id);
            db.tblKhoLuuTrus.Remove(tblKhoLuuTru);
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
