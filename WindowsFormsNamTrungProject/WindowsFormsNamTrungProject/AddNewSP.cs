using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NamTrungProject.Controller;
using ModelDB.Data;
using NamTrungProject.Dao;

namespace NamTrungProject
{
    public partial class AddNewSP : Form
    {
        double cauhinh1 = 0.0;
        double cauhinh2 = 0.0;
        double cauhinh3 = 0.0;
        CauHinhDao cauHinhDao = new CauHinhDao();
        public AddNewSP()
        {
            InitializeComponent();
            try
            {
                var cauhinh1Str = cauHinhDao.GetByName("DG1");
                var cauhinh2Str = cauHinhDao.GetByName("DG2");
                var cauhinh3Str = cauHinhDao.GetByName("DG3");
                double.TryParse(cauhinh1Str.GiaTri, out cauhinh1);
                double.TryParse(cauhinh2Str.GiaTri, out cauhinh2);
                double.TryParse(cauhinh3Str.GiaTri, out cauhinh3);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var dongiagoc = double.Parse(txtDGGoc.Text);
                SanPham sp = new SanPham
                {
                    TenSP = txtTen.Text,
                    DVT = txtDVT.Text,
                    SLDau = double.Parse(txtSLDau.Text),
                    SLTon = double.Parse(txtSLTon.Text),
                    DonGiaGoc = dongiagoc,
                    DonGia1 = double.Parse(txtDG1.Text),
                    DonGia2 = double.Parse(txtDG2.Text),
                    DonGia3 = double.Parse(txtDG3.Text),
                    //DonGia1 = System.Math.Round (dongiagoc + (dongiagoc*(cauhinh1)/100), 1, MidpointRounding.AwayFromZero),
                    //DonGia2 = System.Math.Round (dongiagoc + (dongiagoc*(cauhinh2)/100), 1, MidpointRounding.AwayFromZero),
                    //DonGia3 = System.Math.Round (dongiagoc + (dongiagoc*(cauhinh3)/100), 1, MidpointRounding.AwayFromZero),
                };
                SanPhamController.AddSP(sp);
                MessageBox.Show(@"Thêm mới thành công !");this.Close();
            }
            catch (System.Exception)
            {
                MessageBox.Show(@"Kiểm tra lại số liệu !");
            }
        }

        private void txtDGGoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dongiagoc = 0.0;
                if (double.TryParse(txtDGGoc.Text,out dongiagoc))
                {
                    txtDG1.Text = System.Math.Round(dongiagoc + (dongiagoc * (cauhinh1) / 100), 1, MidpointRounding.AwayFromZero).ToString("##,###");
                    txtDG2.Text = System.Math.Round (dongiagoc + (dongiagoc*(cauhinh2)/100), 1, MidpointRounding.AwayFromZero).ToString("##,###");
                    txtDG3.Text = System.Math.Round (dongiagoc + (dongiagoc*(cauhinh3)/100), 1, MidpointRounding.AwayFromZero).ToString("##,###");
                    txtDGGoc.Text = dongiagoc.ToString("##,###");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
