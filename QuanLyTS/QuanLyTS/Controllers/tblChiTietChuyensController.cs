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
    public class tblChiTietChuyensController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblChiTietChuyens
        public ActionResult Index()
        {
            var tblChiTietChuyens = db.tblChiTietChuyens.Include(t => t.tblKhoLuuTru).Include(t => t.tblNoiSuDung).Include(t => t.tblQuaTrinhDiChuyen).Include(t => t.tblTaiSan).Include(t => t.tblTinhTrang);
            return View(tblChiTietChuyens.ToList());
        }

        // GET: tblChiTietChuyens/Details/5
        public ActionResult Details(string id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietChuyen tblChiTietChuyen = db.tblChiTietChuyens.Single(a=>a.MaLanChuyen == id && a.MaTaiSan == id1);
            if (tblChiTietChuyen == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietChuyen);
        }

        // GET: tblChiTietChuyens/Create
        public ActionResult Create()
        {
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho");
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD");
            ViewBag.MaLanChuyen = new SelectList(db.tblQuaTrinhDiChuyens, "MaLanChuyen","TenLanChuyen");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "TenTaiSan");
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa");
            return View();
        }

        // POST: tblChiTietChuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLanChuyen,MaTaiSan,TinhTrang,MaKho,SoLuong,MaNoiSD")] tblChiTietChuyen tblChiTietChuyen)
        {
            if (ModelState.IsValid)
            {
                db.tblChiTietChuyens.Add(tblChiTietChuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietChuyen.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietChuyen.MaNoiSD);
            ViewBag.MaLanChuyen = new SelectList(db.tblQuaTrinhDiChuyens, "MaLanChuyen", "MaNguoiDieuChuyen", tblChiTietChuyen.MaLanChuyen);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietChuyen.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietChuyen.TinhTrang);
            return View(tblChiTietChuyen);
        }

        // GET: tblChiTietChuyens/Edit/5
        public ActionResult Edit(string id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietChuyen tblChiTietChuyen = db.tblChiTietChuyens.Single(a => a.MaLanChuyen == id && a.MaTaiSan == id1);
            if (tblChiTietChuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietChuyen.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietChuyen.MaNoiSD);
            ViewBag.MaLanChuyen = new SelectList(db.tblQuaTrinhDiChuyens, "MaLanChuyen", "MaNguoiDieuChuyen", tblChiTietChuyen.MaLanChuyen);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietChuyen.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietChuyen.TinhTrang);
            return View(tblChiTietChuyen);
        }

        // POST: tblChiTietChuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLanChuyen,MaTaiSan,TinhTrang,MaKho,SoLuong,MaNoiSD")] tblChiTietChuyen tblChiTietChuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChiTietChuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietChuyen.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietChuyen.MaNoiSD);
            ViewBag.MaLanChuyen = new SelectList(db.tblQuaTrinhDiChuyens, "MaLanChuyen", "MaNguoiDieuChuyen", tblChiTietChuyen.MaLanChuyen);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietChuyen.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietChuyen.TinhTrang);
            return View(tblChiTietChuyen);
        }

        // GET: tblChiTietChuyens/Delete/5
        public ActionResult Delete(string id, string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietChuyen tblChiTietChuyen = db.tblChiTietChuyens.Single(a=>a.MaLanChuyen==id && a.MaTaiSan == id1);
            if (tblChiTietChuyen == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietChuyen);
        }

        // POST: tblChiTietChuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id1)
        {
            tblChiTietChuyen tblChiTietChuyen = db.tblChiTietChuyens.Single(a => a.MaLanChuyen == id && a.MaTaiSan == id1);
            db.tblChiTietChuyens.Remove(tblChiTietChuyen);
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
