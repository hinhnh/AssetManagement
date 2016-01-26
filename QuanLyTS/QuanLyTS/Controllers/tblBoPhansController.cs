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
    public class tblBoPhansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblBoPhans
        public ActionResult Index()
        {
            //var tblBoPhans = db.tblBoPhans.Include(t => t.tblDonVi);
            //return View(tblBoPhans.ToList());
            return View();
        }

        // GET: tblBoPhans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoPhan tblBoPhan = db.tblBoPhans.Find(id);
            if (tblBoPhan == null)
            {
                return HttpNotFound();
            }
            return View(tblBoPhan);
        }

        // GET: tblBoPhans/Create
        public ActionResult Create()
        {
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            return View();
        }

        // POST: tblBoPhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBoPhan,MaDonVi,TenBoPhan,DienThoai")] tblBoPhan tblBoPhan)
        {
            if (ModelState.IsValid)
            {
                db.tblBoPhans.Add(tblBoPhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblBoPhan.MaDonVi);
            return View(tblBoPhan);
        }

        // GET: tblBoPhans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoPhan tblBoPhan = db.tblBoPhans.Find(id);
            if (tblBoPhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblBoPhan.MaDonVi);
            return View(tblBoPhan);
        }

        // POST: tblBoPhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBoPhan,MaDonVi,TenBoPhan,DienThoai")] tblBoPhan tblBoPhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBoPhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblBoPhan.MaDonVi);
            return View(tblBoPhan);
        }

        // GET: tblBoPhans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoPhan tblBoPhan = db.tblBoPhans.Find(id);
            if (tblBoPhan == null)
            {
                return HttpNotFound();
            }
            return View(tblBoPhan);
        }

        // POST: tblBoPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblBoPhan tblBoPhan = db.tblBoPhans.Find(id);
            db.tblBoPhans.Remove(tblBoPhan);
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
