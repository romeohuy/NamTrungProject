using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NamTrungProject.Controller;

namespace NamTrungProject
{
    public partial class FormHoaDon : Form
    {
        public int maHD = 0;
        public int maKH = 0;
        public double tongtien_ = 0;
        public double tienno_ = 0;
        public FormHoaDon()
        {
            InitializeComponent();
            BindingSource bdSource = new BindingSource() { DataSource = HoaDonController.GetAll() };
            gvHoaDon.DataSource = bdSource;
            gvHoaDon.Columns[0].Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gvHoaDon.CurrentRow != null)
            {
                int.TryParse(gvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString(), out maHD);
                int.TryParse(gvHoaDon.CurrentRow.Cells["MaKH"].Value.ToString(), out maKH);
                double.TryParse(gvHoaDon.CurrentRow.Cells["TienNo"].Value.ToString(), out tienno_);
                double.TryParse(gvHoaDon.CurrentRow.Cells["TongTien"].Value.ToString(), out tongtien_);
            }
            else
            {
                MessageBox.Show(@"Bạn chưa chọn hóa đơn?");
            }

            this.Dispose();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show(@"Bạn có muốn xóa hóa đơn này?", @"Xóa hóa đơn",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (gvHoaDon.CurrentRow != null)
                {
                    int.TryParse(gvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString(), out maHD);
                }
                else
                {
                    MessageBox.Show(@"Chọn hóa đơn cần xóa?");
                }

                HoaDonController.Delete(maHD);
                BindingSource bdSource = new BindingSource() { DataSource = HoaDonController.GetAll() };
                gvHoaDon.DataSource = bdSource;
            } 
            
        }

        private void gvHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvHoaDon.CurrentRow != null)
                {
                    int.TryParse(gvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString(), out maHD);
                    int.TryParse(gvHoaDon.CurrentRow.Cells["MaKH"].Value.ToString(), out maKH);
                    double.TryParse(gvHoaDon.CurrentRow.Cells["TienNo"].Value.ToString(), out tienno_);
                    double.TryParse(gvHoaDon.CurrentRow.Cells["TongTien"].Value.ToString(), out tongtien_);
                }
                else
                {
                    MessageBox.Show(@"Bạn chưa chọn hóa đơn?");
                }

                this.Dispose();
            }else if (e.KeyCode == Keys.Delete)
            {
                DialogResult result =  MessageBox.Show(@"Bạn có muốn xóa hóa đơn này?", @"Xóa hóa đơn",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (gvHoaDon.CurrentRow != null)
                    {
                        int.TryParse(gvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString(), out maHD);
                    }
                    else
                    {
                        MessageBox.Show(@"Chọn hóa đơn cần xóa?");
                    }

                    HoaDonController.Delete(maHD);
                    BindingSource bdSource = new BindingSource() { DataSource = HoaDonController.GetAll() };
                    gvHoaDon.DataSource = bdSource;
                } 
            }
        }
    }
}
