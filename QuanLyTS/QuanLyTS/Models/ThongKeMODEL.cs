using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using QuanLyTS.Models;

namespace QuanLyTS.Models
{
    public class ThongKeMODEL
    {
        
        public List<tblKhoTaiSan> tblKho;
        public List<tblTaiSan> tblTaiSan;
        public tblKhoLuuTru kholuutrus;
        public List<tblKhoLuuTru> lst_Khos;
        public List<tblKhoLuuTru> lst_Khos1;

    }
    public class TaiSanNoiSDMODEL
    {
        public List<tblNoiSuDung> lstNoiSDs;
        public List<tblNoiSuDungTaiSan> noisdtaisans;
        public List<tblTaiSan> tblTaiSan;

        public tblNoiSuDung Noisd { get; internal set; }
    }
    public class ThanhLyTS
    {
        public ObjectResult<proThongKeThanhLy_Result> taisans;
    }
    public class TaiSanDieuChuyen
    {
        public List<tblNoiSuDungTaiSan> noisds;
    }
}