using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTS.Models;
using PagedList;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;

namespace QuanLyTS.Controllers
{
    public class tblTaiSansController : Controller
    {
        private QuanLyTSEntities db = new QuanLyTSEntities();

        // GET: tblTaiSans
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var tblTaiSans = db.tblTaiSans.Include(t => t.tblLoaiTaiSan);
            if (!String.IsNullOrEmpty(searchString))
            {
                tblTaiSans = db.tblTaiSans.Where(s => s.TenTaiSan.Contains(searchString)
                                       || s.MaTaiSan.Contains(searchString));
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(tblTaiSans.OrderBy(a => a.MaTaiSan).ToPagedList(pageNumber, pageSize));
        }

        // GET: tblTaiSans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiSan tblTaiSan = db.tblTaiSans.Find(id);
            if (tblTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblTaiSan);
        }
        public ActionResult TongHopTaiSan()
        {
            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            tblTaiSan _model = new tblTaiSan();    
            _model.ListGroupAssets = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            return View(_model);
            
        }
        [HttpPost]
        public ActionResult TongHopTaiSan(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiSan _model = new tblTaiSan();
            ViewData["ID"] = id;
            var tblTaiSans = db.tblTaiSans.Where(t => t.MaLoai == id).ToList();
             _model.MaLoai = id;
             _model.GroupAssetId = db.tblLoaiTaiSans.Where(t => t.MaLoai == id).FirstOrDefault().GroupAssetId;          
            _model.ListGroupAssets = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name", _model.GroupAssetId);          
            _model.ListAssets_Grid = tblTaiSans.ToList();
            return View(_model);
          }
        public ActionResult TaiSanTheoKho()
        {
            var lst_Kho = db.tblKhoLuuTrus.ToList();
            var model = new ThongKeMODEL()
            {
                lst_Khos = lst_Kho,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult TaiSanTheoKho(string id)
        {
            var kholuutru = db.tblKhoLuuTrus.Single(a => a.MaKho == id);
            var Kho = kholuutru.tblKhoTaiSans.Where(t => t.MaKho == id).ToList();
            var taisan = db.tblTaiSans.ToList();

            var lst_Kho = db.tblKhoLuuTrus.ToList();


            var model = new ThongKeMODEL()
            {
                lst_Khos = lst_Kho,
                tblKho = Kho,
                tblTaiSan = taisan,
                kholuutrus = kholuutru,
            };

            return View(model);
        }
        public ActionResult TaiSanTheoNoiSD()
        {
            var listDonvi = new List<tblDonVi>();
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            ViewData["CountDonvi"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult TaiSanTheoNoiSD(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["ID"] = id;
            var tblTaiSans = db.tblTaiSans.Where(t => t.MaDonVi == id).ToList();
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", id);
            ViewData["CountDonvi"] = tblTaiSans.Count;
            return View(tblTaiSans.ToList());

        }

        public ActionResult TaiSanDieuChuyen()
        {
            var noisd = db.tblNoiSuDungTaiSans.ToList();
            var model = new TaiSanDieuChuyen()
            {
                noisds = noisd,
            };
            return View(model);
        }
        // GET: tblTaiSans/Create
        public ActionResult Create()
        {
            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            ViewBag.ListDuAn = new SelectList(db.tblDuAns, "Id", "Name");
            ViewBag.ListStatus = new SelectList(db.tblTinhTrangs, "StatusId", "Name");
            return View();
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetTypeAssetByParentId(string parentId)
        {
            var lstTypeAssets = db.tblLoaiTaiSans.Where(item => item.GroupAssetId == parentId);
            SelectList list = new SelectList(lstTypeAssets, "MaLoai", "TenLoai", 0);
            return Json(list);
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "MaTaiSan,MaLoai,TenTaiSan,ThongSoKyThuat,NamSX,XuatXu,ThoiGianBaoHanh,DonViTinh,GhiChu,SerialNumber,NgayMua,MaDuAn,StatusId,Soluong,MaDonVi,NgayBanGiao,NguyenGia")] tblTaiSan tblTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.tblTaiSans.Add(tblTaiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            }

            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            ViewBag.ListDuAn = new SelectList(db.tblDuAns, "Id", "Name");
            ViewBag.ListStatus = new SelectList(db.tblTinhTrangs, "StatusId", "Name");
            return View(tblTaiSan);
        }

        // [HttpPost]
        public ActionResult GenerateMaTs(string assetTypeCode)
        {
            if (!string.IsNullOrEmpty(assetTypeCode))
            {
                var countTs = (db.tblTaiSans.Where(item => item.MaLoai.Equals(assetTypeCode)).Count() + 1).ToString("000");
                return Json(assetTypeCode + "-" + countTs, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

       
        // GET: tblTaiSans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiSan tblTaiSan = db.tblTaiSans.Find(id);
            if (tblTaiSan == null)
            {
                return HttpNotFound();
            }
          

            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblTaiSan.MaDonVi);
            ViewBag.ListDuAn = new SelectList(db.tblDuAns, "Id", "Name", tblTaiSan.MaDuAn);
            ViewBag.ListStatus = new SelectList(db.tblTinhTrangs, "StatusId", "Name", tblTaiSan.StatusId);


            return View(tblTaiSan);
        }
              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTaiSan,MaLoai,TenTaiSan,ThongSoKyThuat,NamSX,XuatXu,ThoiGianBaoHanh,DonViTinh,GhiChu,SerialNumber,NgayMua,MaDuAn,StatusId,Soluong,MaDonVi,NgayBanGiao,NguyenGia")] tblTaiSan tblTaiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTaiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            }

                      

            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi", tblTaiSan.MaDonVi);
            ViewBag.ListDuAn = new SelectList(db.tblDuAns, "Id", "Name", tblTaiSan.MaDuAn);
            ViewBag.ListStatus = new SelectList(db.tblTinhTrangs, "StatusId", "Name", tblTaiSan.StatusId);


            return View(tblTaiSan);
        }

        // GET: tblTaiSans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTaiSan tblTaiSan = db.tblTaiSans.Find(id);
            if (tblTaiSan == null)
            {
                return HttpNotFound();
            }
            return View(tblTaiSan);
        }

        // POST: tblTaiSans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblTaiSan tblTaiSan = db.tblTaiSans.Find(id);
            db.tblTaiSans.Remove(tblTaiSan);
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

        public ActionResult ExportDataByTypeAsset(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            String constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = string.Format("select * From tblTaiSan where MaLoai ='{0}'", id);
            DataTable dt = new DataTable();
            dt.TableName = "tblTaiSan";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

            return RedirectToAction("ExportDataByTypeAsset", "tblTaiSans");
        }

        public ActionResult ExportDataByDepartment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            String constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = string.Format("select * From tblTaiSan where Madonvi ='{0}'", id);
            DataTable dt = new DataTable();
            dt.TableName = "tblTaiSan";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

            return RedirectToAction("ExportDataByDepartment", "tblTaiSans");
        }
        //Maintenance
        public ActionResult Maintenance()
        {
            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            tblTaiSan _model = new tblTaiSan();
            _model.ListGroupAssets = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.NhomTS = new SelectList(db.tblGroupAssets, "GroupAssetId", "Name");
            ViewBag.MaDonVi = new SelectList(db.tblDonVis, "MaDonVi", "TenDonVi");
            ViewBag.ListDuAn = new SelectList(db.tblDuAns, "Id", "Name");
            ViewBag.ListStatus = new SelectList(db.tblTinhTrangs, "StatusId", "Name");
            return View(_model);
        }
    }
}
