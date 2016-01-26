using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTS_29_11_2015_
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap x = new DangNhap();
            x.Show();

        }

        private void nhậpMớiTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapMoiTS f = new NhapMoiTS();
            f.Show();
                    
        }

        private void thiếtLậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapNhapSuaChua f = new CapNhapSuaChua();
            f.Show();

        }

        private void điềuChuyểnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DieuChuyen f = new DieuChuyen();
            f.Show();

        }

        private void thanhLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThanhLy f = new ThanhLy();
            f.Show();
        }

        private void quảnLýDanhMụcTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucTaiSanVaDonVi f = new DanhMucTaiSanVaDonVi();
            f.Show();
        }

        private void thốngKêTheoĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeTheoDonVi f = new ThongKeTheoDonVi();
            f.Show();
        }

        private void thốngKêTheoLoạiTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeTheoLoai f = new ThongKeTheoLoai();
            f.Show();

        }

        private void tìmKiếmTàiSảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimKiem f= new TimKiem();
            f.Show();
        }

        private void thiếtLậpCáchTínhKhấuHaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThietLapKhauHao f = new ThietLapKhauHao();
            f.Show();
        }

        private void phầnQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhanQuyen f = new PhanQuyen();
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void biểuMẫuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BieuMau f = new BieuMau();
            f.Show();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDanSuDung f = new HuongDanSuDung();
            f.Show();
        }

        private void đềXuấtThanhLýTừĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeXuatTuDonVi f = new DeXuatTuDonVi();
            f.Show();
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiaSe f = new ChiaSe();
            f.Show();
        }

        private void đềNghịTrangCấpTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangCapTaiSan f = new TrangCapTaiSan();
            f.Show();
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeHoachMuaSam f = new KeHoachMuaSam();
            f.Show();
        }

        private void xemKhấuHaoTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoKhauHao f = new frmBaoCaoKhauHao();
            f.Show();
        }

        private void kiểmKêTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKiemKeTS f = new frmKiemKeTS();
            f.Show();
        }
    }
}
