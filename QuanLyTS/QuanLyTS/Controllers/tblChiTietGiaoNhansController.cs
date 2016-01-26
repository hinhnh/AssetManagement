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
    public class tblChiTietGiaoNhansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblChiTietGiaoNhans
        public ActionResult Index()
        {
            //var tblChiTietGiaoNhans = db.tblChiTietGiaoNhans.Include(t => t.tblKhoLuuTru).Include(t => t.tblPhieuBanGiao).Include(t => t.tblTaiSan).Include(t => t.tblTinhTrang);
            //return View(tblChiTietGiaoNhans.ToList());
            return View();
        }

        // GET: tblChiTietGiaoNhans/Details/5
        public ActionResult Details(string id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietGiaoNhan tblChiTietGiaoNhan = db.tblChiTietGiaoNhans.Single(a=>a.MaPhieuGiao == id && a.MaTaiSan == id1);
            if (tblChiTietGiaoNhan == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietGiaoNhan);
        }

        // GET: tblChiTietGiaoNhans/Create
        public ActionResult Create()
        {
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho");
            ViewBag.MaPhieuGiao = new SelectList(db.tblPhieuBanGiaos, "MaPhieuGiao", "TenPhieuGiao");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "TenTaiSan");
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa");
            return View();
        }

        // POST: tblChiTietGiaoNhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuGiao,MaTaiSan,TyLeKhauHao,SoLuong,DonGia,TinhTrang,MaKho,DonGiaKhauHao,NgayThangSD")] tblChiTietGiaoNhan tblChiTietGiaoNhan)
        {
            if (ModelState.IsValid)
            {
                db.tblChiTietGiaoNhans.Add(tblChiTietGiaoNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietGiaoNhan.MaKho);
            ViewBag.MaPhieuGiao = new SelectList(db.tblPhieuBanGiaos, "MaPhieuGiao", "MaDonVi", tblChiTietGiaoNhan.MaPhieuGiao);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietGiaoNhan.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietGiaoNhan.TinhTrang);
            return View(tblChiTietGiaoNhan);
        }

        // GET: tblChiTietGiaoNhans/Edit/5
        public ActionResult Edit(string id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietGiaoNhan tblChiTietGiaoNhan = db.tblChiTietGiaoNhans.Single(a => a.MaPhieuGiao == id && a.MaTaiSan == id1);
            if (tblChiTietGiaoNhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietGiaoNhan.MaKho);
            ViewBag.MaPhieuGiao = new SelectList(db.tblPhieuBanGiaos, "MaPhieuGiao", "MaDonVi", tblChiTietGiaoNhan.MaPhieuGiao);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietGiaoNhan.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietGiaoNhan.TinhTrang);
            return View(tblChiTietGiaoNhan);
        }

        // POST: tblChiTietGiaoNhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuGiao,MaTaiSan,TyLeKhauHao,SoLuong,DonGia,TinhTrang,MaKho,DonGiaKhauHao,NgayThangSD")] tblChiTietGiaoNhan tblChiTietGiaoNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChiTietGiaoNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietGiaoNhan.MaKho);
            ViewBag.MaPhieuGiao = new SelectList(db.tblPhieuBanGiaos, "MaPhieuGiao", "MaDonVi", tblChiTietGiaoNhan.MaPhieuGiao);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietGiaoNhan.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietGiaoNhan.TinhTrang);
            return View(tblChiTietGiaoNhan);
        }

        // GET: tblChiTietGiaoNhans/Delete/5
        public ActionResult Delete(string id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietGiaoNhan tblChiTietGiaoNhan = db.tblChiTietGiaoNhans.Single(a => a.MaPhieuGiao == id && a.MaTaiSan == id1);
            if (tblChiTietGiaoNhan == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietGiaoNhan);
        }

        // POST: tblChiTietGiaoNhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id,string id1)
        {
            tblChiTietGiaoNhan tblChiTietGiaoNhan = db.tblChiTietGiaoNhans.Single(a => a.MaPhieuGiao == id && a.MaTaiSan == id1);
            db.tblChiTietGiaoNhans.Remove(tblChiTietGiaoNhan);
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
