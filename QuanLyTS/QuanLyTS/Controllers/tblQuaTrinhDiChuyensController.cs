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
    public class tblQuaTrinhDiChuyensController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblQuaTrinhDiChuyens
        public ActionResult Index()
        {
            var tblQuaTrinhDiChuyens = db.tblQuaTrinhDiChuyens.Include(t => t.tblCanBoGiaoVien);
            return View(tblQuaTrinhDiChuyens.ToList());
        }

        // GET: tblQuaTrinhDiChuyens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen = db.tblQuaTrinhDiChuyens.Find(id);
            if (tblQuaTrinhDiChuyen == null)
            {
                return HttpNotFound();
            }
            return View(tblQuaTrinhDiChuyen);
        }

        // GET: tblQuaTrinhDiChuyens/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiDieuChuyen = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen");
            return View();
        }

        // POST: tblQuaTrinhDiChuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLanChuyen,NgayChuyen,MaNguoiDieuChuyen,GhiChu,TenLanChuyen")] tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen)
        {
            if (ModelState.IsValid)
            {
                db.tblQuaTrinhDiChuyens.Add(tblQuaTrinhDiChuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiDieuChuyen = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblQuaTrinhDiChuyen.MaNguoiDieuChuyen);
            return View(tblQuaTrinhDiChuyen);
        }

        // GET: tblQuaTrinhDiChuyens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen = db.tblQuaTrinhDiChuyens.Find(id);
            if (tblQuaTrinhDiChuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiDieuChuyen = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblQuaTrinhDiChuyen.MaNguoiDieuChuyen);
            return View(tblQuaTrinhDiChuyen);
        }

        // POST: tblQuaTrinhDiChuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLanChuyen,NgayChuyen,MaNguoiDieuChuyen,GhiChu,TenLanChuyen")] tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblQuaTrinhDiChuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDieuChuyen = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblQuaTrinhDiChuyen.MaNguoiDieuChuyen);
            return View(tblQuaTrinhDiChuyen);
        }

        // GET: tblQuaTrinhDiChuyens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen = db.tblQuaTrinhDiChuyens.Find(id);
            if (tblQuaTrinhDiChuyen == null)
            {
                return HttpNotFound();
            }
            return View(tblQuaTrinhDiChuyen);
        }

        // POST: tblQuaTrinhDiChuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblQuaTrinhDiChuyen tblQuaTrinhDiChuyen = db.tblQuaTrinhDiChuyens.Find(id);
            db.tblQuaTrinhDiChuyens.Remove(tblQuaTrinhDiChuyen);
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
