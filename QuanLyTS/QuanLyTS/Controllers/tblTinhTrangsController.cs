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
    public class tblTinhTrangsController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblTinhTrangs
        public ActionResult Index()
        {
            return View(db.tblTinhTrangs.ToList());
        }

        // GET: tblTinhTrangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTinhTrang tblTinhTrang = db.tblTinhTrangs.Find(id);
            if (tblTinhTrang == null)
            {
                return HttpNotFound();
            }
            return View(tblTinhTrang);
        }

        // GET: tblTinhTrangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblTinhTrangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TinhTrang,MoTa,GhiChu")] tblTinhTrang tblTinhTrang)
        {
            if (ModelState.IsValid)
            {
                db.tblTinhTrangs.Add(tblTinhTrang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTinhTrang);
        }

        // GET: tblTinhTrangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTinhTrang tblTinhTrang = db.tblTinhTrangs.Find(id);
            if (tblTinhTrang == null)
            {
                return HttpNotFound();
            }
            return View(tblTinhTrang);
        }

        // POST: tblTinhTrangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TinhTrang,MoTa,GhiChu")] tblTinhTrang tblTinhTrang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTinhTrang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTinhTrang);
        }

        // GET: tblTinhTrangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTinhTrang tblTinhTrang = db.tblTinhTrangs.Find(id);
            if (tblTinhTrang == null)
            {
                return HttpNotFound();
            }
            return View(tblTinhTrang);
        }

        // POST: tblTinhTrangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTinhTrang tblTinhTrang = db.tblTinhTrangs.Find(id);
            db.tblTinhTrangs.Remove(tblTinhTrang);
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
