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
    public class tblChiTietPhieuTrasController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblChiTietPhieuTras
        public ActionResult Index()
        {
            var tblChiTietPhieuTras = db.tblChiTietPhieuTras.Where(a=>a.TrangThai=="Cho tra").Include(t => t.tblCanBoGiaoVien).Include(t => t.tblKhoLuuTru).Include(t => t.tblNoiSuDung).Include(t => t.tblTaiSan).Include(t => t.tblTinhTrang);
            return View(tblChiTietPhieuTras.ToList());
        }

        public ActionResult TraTaiSan()
        {
            var tblChiTietPhieuTras = db.tblChiTietPhieuTras.Include(t => t.tblCanBoGiaoVien).Include(t => t.tblKhoLuuTru).Include(t => t.tblNoiSuDung).Include(t => t.tblTaiSan).Include(t => t.tblTinhTrang);
            return View(tblChiTietPhieuTras.ToList());
        }

        // GET: tblChiTietPhieuTras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuTra tblChiTietPhieuTra = db.tblChiTietPhieuTras.Find(id);
            if (tblChiTietPhieuTra == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietPhieuTra);
        }

        // GET: tblChiTietPhieuTras/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiNhan = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen");
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho");
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD");
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "TenTaiSan");
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa");
            return View();
        }

        // POST: tblChiTietPhieuTras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuTra,MaTaiSan,MaKho,TinhTrang,SoLuong,MaNoiSD,MaNguoiTra,MaNguoiNhan,NgayTra,TrangThai")] tblChiTietPhieuTra tblChiTietPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.tblChiTietPhieuTras.Add(tblChiTietPhieuTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiNhan = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuTra.MaNguoiNhan);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuTra.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuTra.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietPhieuTra.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuTra.TinhTrang);
            return View(tblChiTietPhieuTra);
        }

        // GET: tblChiTietPhieuTras/Edit/5
        public ActionResult Edit(int? id, string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuTra tblChiTietPhieuTra = db.tblChiTietPhieuTras.Single(a=>a.MaPhieuTra == id && a.MaTaiSan == id1);
            if (tblChiTietPhieuTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiNhan = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuTra.MaNguoiNhan);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuTra.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuTra.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietPhieuTra.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuTra.TinhTrang);
            return View(tblChiTietPhieuTra);
        }

        // POST: tblChiTietPhieuTras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuTra,MaTaiSan,MaKho,TinhTrang,SoLuong,MaNoiSD,MaNguoiTra,MaNguoiNhan,NgayTra,TrangThai")] tblChiTietPhieuTra tblChiTietPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChiTietPhieuTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiNhan = new SelectList(db.tblCanBoGiaoViens, "MaGiaoVien", "HoTen", tblChiTietPhieuTra.MaNguoiNhan);
            ViewBag.MaKho = new SelectList(db.tblKhoLuuTrus, "MaKho", "TenKho", tblChiTietPhieuTra.MaKho);
            ViewBag.MaNoiSD = new SelectList(db.tblNoiSuDungs, "MaNoiSD", "TenNoiSD", tblChiTietPhieuTra.MaNoiSD);
            ViewBag.MaTaiSan = new SelectList(db.tblTaiSans, "MaTaiSan", "MaLoai", tblChiTietPhieuTra.MaTaiSan);
            ViewBag.TinhTrang = new SelectList(db.tblTinhTrangs, "TinhTrang", "MoTa", tblChiTietPhieuTra.TinhTrang);
            return View(tblChiTietPhieuTra);
        }

        // GET: tblChiTietPhieuTras/Delete/5
        public ActionResult Delete(int? id,string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChiTietPhieuTra tblChiTietPhieuTra = db.tblChiTietPhieuTras.Single(a => a.MaPhieuTra == id && a.MaTaiSan == id1);
            if (tblChiTietPhieuTra == null)
            {
                return HttpNotFound();
            }
            return View(tblChiTietPhieuTra);
        }

        // POST: tblChiTietPhieuTras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,string id1)
        {
            tblChiTietPhieuTra tblChiTietPhieuTra = db.tblChiTietPhieuTras.Single(a => a.MaPhieuTra == id && a.MaTaiSan == id1);
            db.tblChiTietPhieuTras.Remove(tblChiTietPhieuTra);
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
