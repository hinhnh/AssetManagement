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
    public partial class DieuChuyen : Form
    {
        public DieuChuyen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PhieuDieuChuyenTS f = new PhieuDieuChuyenTS();
            f.Show();
        }
    }
}
