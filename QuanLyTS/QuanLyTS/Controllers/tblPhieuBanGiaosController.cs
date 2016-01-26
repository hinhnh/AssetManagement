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
    public class tblPhieuBanGiaosController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblPhieuBanGiaos
        public ActionResult Index()
        {
            var tblPhieuBanGiaos = db.tblPhieuBanGiaos.Include(t => t.tblCanBoGiaoVien).Include(t => t.tblDonVi);
            return View(tblPhieuBanGiaos.ToList());
        }

        // GET: tblPhieuBanGiaos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuBanGiao tblPhieuBanGiao = db.tblPhieuBanGiaos.Find(id);
            if (tblPhieuBanGiao == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuBanGiao);
        }

        // GET: tblPhieuBanGiaos/Create
        public ActionResult Create()
        {
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            return View();
        }

        // POST: tblPhieuBanGiaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuGiao,MaDonVi,MaGiaoVien,NgayGiao,TenPhieuGiao")] tblPhieuBanGiao tblPhieuBanGiao)
        {
            if (ModelState.IsValid)
            {
                db.tblPhieuBanGiaos.Add(tblPhieuBanGiao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblPhieuBanGiao.MaGiaoVien);
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblPhieuBanGiao.MaDonVi);
            return View(tblPhieuBanGiao);
        }

        // GET: tblPhieuBanGiaos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuBanGiao tblPhieuBanGiao = db.tblPhieuBanGiaos.Find(id);
            if (tblPhieuBanGiao == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblPhieuBanGiao.MaGiaoVien);
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblPhieuBanGiao.MaDonVi);
            return View(tblPhieuBanGiao);
        }

        // POST: tblPhieuBanGiaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuGiao,MaDonVi,MaGiaoVien,NgayGiao,TenPhieuGiao")] tblPhieuBanGiao tblPhieuBanGiao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPhieuBanGiao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiaoVien = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblPhieuBanGiao.MaGiaoVien);
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblPhieuBanGiao.MaDonVi);
            return View(tblPhieuBanGiao);
        }

        // GET: tblPhieuBanGiaos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuBanGiao tblPhieuBanGiao = db.tblPhieuBanGiaos.Find(id);
            if (tblPhieuBanGiao == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuBanGiao);
        }

        // POST: tblPhieuBanGiaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblPhieuBanGiao tblPhieuBanGiao = db.tblPhieuBanGiaos.Find(id);
            db.tblPhieuBanGiaos.Remove(tblPhieuBanGiao);
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
