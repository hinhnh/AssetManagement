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
    public class tblChiTietPhieuMuonsController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblChiTietPhieuMuons
        public ActionResult Index()
        {
            var tblChiTietPhieuMuons = db.tblChiTietPhieuMuons.Where(a=>a.TrangThai == "Cho muon");
            return View(tblChiTietPhieuMuons.ToList());
        }
        public ActionResult MuonTaiSan()
        {
            var tblChiTietPhieuMuons = db.tblChiTietPhieuMuons;
            return View(tblChiTietPhieuMuons.ToList());
        }

        // GET: tblChiTietPhieuMuons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuMuon tblChiTietPhieuMuon = db.tblChiTietPhieuMuons.Find(id);
            if (tblChiTietPhieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietPhieuMuon);
        }

        // GET: tblChiTietPhieuMuons/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiGiao = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen");
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho");
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "TenTaiSan");
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa");
            return View();
        }

        // POST: tblChiTietPhieuMuons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaTaiSan,TinhTrang,MaKho,SoLuong,MaNoiSD,MaNguoiGiao,MaNguoiMuon,NgayMuon,TrangThai")] tblChiTietPhieuMuon tblChiTietPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.tblChiTietPhieuMuons.Add(tblChiTietPhieuMuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiGiao = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuMuon.MaNguoiGiao);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuMuon.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuMuon.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietPhieuMuon.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuMuon.TinhTrang);
            return View(tblChiTietPhieuMuon);
        }

        // GET: tblChiTietPhieuMuons/Edit/5
        public ActionResult Edit(int? id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuMuon tblChiTietPhieuMuon = db.tblChiTietPhieuMuons.Single(a=>a.MaPhieu == id && a.MaTaiSan == id1);
            if (tblChiTietPhieuMuon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiGiao = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuMuon.MaNguoiGiao);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuMuon.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuMuon.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "TenTaiSan", tblChiTietPhieuMuon.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuMuon.TinhTrang);
            return View(tblChiTietPhieuMuon);
        }

        // POST: tblChiTietPhieuMuons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaTaiSan,TinhTrang,MaKho,SoLuong,MaNoiSD,MaNguoiGiao,MaNguoiMuon,NgayMuon,TrangThai")] tblChiTietPhieuMuon tblChiTietPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChiTietPhieuMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiGiao = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuMuon.MaNguoiGiao);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuMuon.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuMuon.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietPhieuMuon.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuMuon.TinhTrang);
            return View(tblChiTietPhieuMuon);
        }

        // GET: tblChiTietPhieuMuons/Delete/5
        public ActionResult Delete(int? id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuMuon tblChiTietPhieuMuon = db.tblChiTietPhieuMuons.Single(a => a.MaPhieu == id && a.MaTaiSan == id1);
            if (tblChiTietPhieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietPhieuMuon);
        }

        // POST: tblChiTietPhieuMuons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string id1)
        {
            tblChiTietPhieuMuon tblChiTietPhieuMuon = db.tblChiTietPhieuMuons.Single(a => a.MaPhieu == id && a.MaTaiSan == id1);
            db.tblChiTietPhieuMuons.Remove(tblChiTietPhieuMuon);
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
