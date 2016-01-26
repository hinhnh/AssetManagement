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
    public class tblNoiSuDungsController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblNoiSuDungs
        public ActionResult Index()
        {
            var tblNoiSuDungs = db.tblNoiSuDungs.Include(t => t.tblBoPhan);
            return View(tblNoiSuDungs.ToList());
        }

        // GET: tblNoiSuDungs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDung tblNoiSuDung = db.tblNoiSuDungs.Find(id);
            if (tblNoiSuDung == null)
            {
                return HttpNotFound();
            }
            return View(tblNoiSuDung);
        }

        // GET: tblNoiSuDungs/Create
        public ActionResult Create()
        {
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan");
            return View();
        }

        // POST: tblNoiSuDungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNoiSD,TenNoiSD,MaBoPhan,GhiChu")] tblNoiSuDung tblNoiSuDung)
        {
            if (ModelState.IsValid)
            {
                db.tblNoiSuDungs.Add(tblNoiSuDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblNoiSuDung.MaBoPhan);
            return View(tblNoiSuDung);
        }

        // GET: tblNoiSuDungs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDung tblNoiSuDung = db.tblNoiSuDungs.Find(id);
            if (tblNoiSuDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblNoiSuDung.MaBoPhan);
            return View(tblNoiSuDung);
        }

        // POST: tblNoiSuDungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNoiSD,TenNoiSD,MaBoPhan,GhiChu")] tblNoiSuDung tblNoiSuDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNoiSuDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBoPhan = new SelectList(db.tblBoPhans, "MaBoPhan", "TenBoPhan", tblNoiSuDung.MaBoPhan);
            return View(tblNoiSuDung);
        }

        // GET: tblNoiSuDungs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNoiSuDung tblNoiSuDung = db.tblNoiSuDungs.Find(id);
            if (tblNoiSuDung == null)
            {
                return HttpNotFound();
            }
            return View(tblNoiSuDung);
        }

        // POST: tblNoiSuDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblNoiSuDung tblNoiSuDung = db.tblNoiSuDungs.Find(id);
            db.tblNoiSuDungs.Remove(tblNoiSuDung);
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
