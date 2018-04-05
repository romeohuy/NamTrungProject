using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NamTrungProject.Controller;
using NamTrungProject.Models;

namespace NamTrungProject
{
    public partial class ThemSP : Form
    {

        
        public ThemSP()
        {
            InitializeComponent();
        }
        public string tensp = null;
        public string dvt = null;
        public double slmua = 0;
        public double dongiagoc = 0;
        public double dongia = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //ct = new ChiTietHoaDonModel();
                tensp = txtTen.Text;
                dvt = txtDVT.Text;
                slmua = double.Parse(txtSoLuong.Text);
                dongiagoc = double.Parse(txtGiaGoc.Text);
                dongia = double.Parse(txtGiaBan.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ !");
                return;
            }
            this.Dispose();
        }
    }
}
