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
    public class tblDonVisController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblDonVis
        public ActionResult Index()
        {
            return View(db.tblDonVis.ToList());
        }

        // GET: tblDonVis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDonVi tblDonVi = db.tblDonVis.Find(id);
            if (tblDonVi == null)
            {
                return HttpNotFound();
            }
            return View(tblDonVi);
        }

        // GET: tblDonVis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDonVis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonVi,TenDonVi,DiaChi,SoDienThoai,Website,EMail,LoaiDonVi")] tblDonVi tblDonVi)
        {
            if (ModelState.IsValid)
            {
                db.tblDonVis.Add(tblDonVi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDonVi);
        }

        // GET: tblDonVis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDonVi tblDonVi = db.tblDonVis.Find(id);
            if (tblDonVi == null)
            {
                return HttpNotFound();
            }
            return View(tblDonVi);
        }

        // POST: tblDonVis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonVi,TenDonVi,DiaChi,SoDienThoai,Website,EMail,LoaiDonVi")] tblDonVi tblDonVi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDonVi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDonVi);
        }

        // GET: tblDonVis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDonVi tblDonVi = db.tblDonVis.Find(id);
            if (tblDonVi == null)
            {
                return HttpNotFound();
            }
            return View(tblDonVi);
        }

        // POST: tblDonVis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblDonVi tblDonVi = db.tblDonVis.Find(id);
            db.tblDonVis.Remove(tblDonVi);
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
