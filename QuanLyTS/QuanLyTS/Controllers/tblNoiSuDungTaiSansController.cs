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
    public class tblNoiSuDungTaiSansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblNoiSuDungTaiSans
        public ActionResult Index()
        {
            var tblNoiSuDungTaiSans = db.tblNoiSuDungTaiSans.Include(t => t.tblNoiSuDung).Include(t => t.tblTaiSan);
            return View(tblNoiSuDungTaiSans.ToList());
        }

        // GET: tblNoiSuDungTaiSans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDungTaiSan tblNoiSuDungTaiSan = db.tblNoiSuDungTaiSans.Find(id);
            if (tblNoiSuDungTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblNoiSuDungTaiSan);
        }

        // GET: tblNoiSuDungTaiSans/Create
        public ActionResult Create()
        {
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai");
            return View();
        }

        // POST: tblNoiSuDungTaiSans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNoiSD,MaTaiSan,SoLuong")] tblNoiSuDungTaiSan tblNoiSuDungTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.tblNoiSuDungTaiSans.Add(tblNoiSuDungTaiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblNoiSuDungTaiSan.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblNoiSuDungTaiSan.MaTaiSan);
            return View(tblNoiSuDungTaiSan);
        }

        // GET: tblNoiSuDungTaiSans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDungTaiSan tblNoiSuDungTaiSan = db.tblNoiSuDungTaiSans.Find(id);
            if (tblNoiSuDungTaiSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblNoiSuDungTaiSan.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblNoiSuDungTaiSan.MaTaiSan);
            return View(tblNoiSuDungTaiSan);
        }

        // POST: tblNoiSuDungTaiSans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNoiSD,MaTaiSan,SoLuong")] tblNoiSuDungTaiSan tblNoiSuDungTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNoiSuDungTaiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblNoiSuDungTaiSan.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblNoiSuDungTaiSan.MaTaiSan);
            return View(tblNoiSuDungTaiSan);
        }

        // GET: tblNoiSuDungTaiSans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDungTaiSan tblNoiSuDungTaiSan = db.tblNoiSuDungTaiSans.Find(id);
            if (tblNoiSuDungTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblNoiSuDungTaiSan);
        }

        // POST: tblNoiSuDungTaiSans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblNoiSuDungTaiSan tblNoiSuDungTaiSan = db.tblNoiSuDungTaiSans.Find(id);
            db.tblNoiSuDungTaiSans.Remove(tblNoiSuDungTaiSan);
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
