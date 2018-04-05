using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelDB.Data;
using NamTrungProject.Dao;

namespace NamTrungProject
{
    public partial class FormCauHinh : Form
    {
        private CauHinhDao cauHinhDao;
        public FormCauHinh()
        {
            InitializeComponent();
            cauHinhDao = new CauHinhDao();
        }

        private void btnCapNhatCauHinh_Click(object sender, EventArgs e)
        {
            var cauhinh1 = 0.0;
            var cauhinh2 = 0.0;
            var cauhinh3 = 0.0;
            if (!double.TryParse(txtPhanTramDonGia1.Text,out cauhinh1) ||!double.TryParse(txtPhanTramDonGia2.Text,out cauhinh2) || !double.TryParse(txtPhanTramDonGia3.Text,out cauhinh3) )
            {
                MessageBox.Show(@"Giá trị nhập chưa chính xác.");
                return;
            }
            cauHinhDao.Update("DG1", txtPhanTramDonGia1.Text);
            cauHinhDao.Update("DG2", txtPhanTramDonGia2.Text);
            cauHinhDao.Update("DG3", txtPhanTramDonGia3.Text);
            foreach (var item in SanPham.All())
            {
                try
                {
                    SanPham sp = SanPham.Find(k => k.MaSP == item.MaSP).SingleOrDefault();
                    sp.TenSP = item.TenSP;
                    sp.SLDau = item.SLDau;
                    sp.SLTon = item.SLTon;
                    sp.DVT = item.DVT;
                    if (sp.DonGiaGoc != null)
                    {
                        var dongiagoc = sp.DonGiaGoc.Value;
                        sp.DonGia1 = System.Math.Round(dongiagoc + (dongiagoc * (cauhinh1) / 100), 1, MidpointRounding.AwayFromZero);
                        sp.DonGia2 = System.Math.Round(dongiagoc + (dongiagoc * (cauhinh2) / 100), 1, MidpointRounding.AwayFromZero);
                        sp.DonGia3 = System.Math.Round(dongiagoc + (dongiagoc * (cauhinh3) / 100), 1, MidpointRounding.AwayFromZero);
                    }

                    sp.Update();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            MessageBox.Show(@"Cập nhật thành công");
        }

        private void FormCauHinh_Load(object sender, EventArgs e)
        {
            var cauhinh1 = cauHinhDao.GetByName("DG1");
            var cauhinh2 = cauHinhDao.GetByName("DG2");
            var cauhinh3 = cauHinhDao.GetByName("DG3");
            txtPhanTramDonGia1.Text = cauhinh1.GiaTri;
            txtPhanTramDonGia2.Text = cauhinh2.GiaTri;
            txtPhanTramDonGia3.Text = cauhinh3.GiaTri;
        }
    }
}
