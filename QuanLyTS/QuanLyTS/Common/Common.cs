using QuanLyTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTS.Controllers
{
    public class Common
    {
        private static QuanLyTSEntities db = new QuanLyTSEntities();
        //public static List<tblLoaiTaiSan> GetLoaiTSByGroup()
        //{
        //    var lstFathers = db.tblLoaiTaiSans.Where(item => item.ParentID == null);
        //    var lstChilds = db.tblLoaiTaiSans.Where(item => item.ParentID != null);
        //    var listLoaiTS = new List<tblLoaiTaiSan>();
        //    foreach (var item in lstFathers )
        //    {
        //        listLoaiTS.Add(item);
        //        foreach (var child in lstChilds)
        //        {
        //            if (child.ParentID == item.MaLoai)
        //            {
        //                var itemChild = new tblLoaiTaiSan
        //                {
        //                    MaLoai = child.MaLoai,
        //                    TenLoai = "--" + child.TenLoai,
        //                    ParentID = child.ParentID
        //                };
        //                listLoaiTS.Add(itemChild);
        //            }

        //        }

        //    }

        //    return listLoaiTS;

        ////}


    }
}