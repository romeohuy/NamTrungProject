using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NamTrungProject.Controller;
using ModelDB.Data;

namespace NamTrungProject
{
    public partial class FormQuanLyKH : Form
    {
        public FormQuanLyKH()
        {
            InitializeComponent();
        }
        private void FormQuanLyKH_Load(object sender, EventArgs e)
        {
            BindingSource bdSource = new BindingSource() { DataSource = KhachHangController.GetAll() };
            gvKhachHang.DataSource = bdSource;
            //txtID.DataBindings.Add("text", bdSource, "MaKH");
            //txtName.DataBindings.Add("text", bdSource, "TenKH");
            //txtPhone.DataBindings.Add("text", bdSource, "DienThoai");
            //txtAddress.DataBindings.Add("text", bdSource, "DiaChi");
            //txtCapKh.DataBindings.Add("text", bdSource, "CapKH");
            gvKhachHang.Columns[0].Visible = false;
            gvKhachHang.Columns[7].Visible = false;
            gvKhachHang.Columns[8].Visible = false;
        }

        private void XoaField()
        {
            txtAddress.Clear();
            txtCapKh.Clear();
           // txtConno.Clear();
            txtDatra.Clear();
            txtGhichu.Clear();
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtTienno.Clear();
            txtTongtien.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int capkh = 0;
                if (!int.TryParse(txtCapKh.Text, out capkh))
                {
                    MessageBox.Show("Cấp khách hàng ko đúng");
                    return;
                }
                KhachHang khNew = new KhachHang()
                {
                    TenKH = txtName.Text,
                    DienThoai = txtPhone.Text,
                    DiaChi = txtAddress.Text,
                    CapKH = capkh,
                    TienNo = double.Parse(txtTienno.Text),
                    DaTra = double.Parse(txtDatra.Text),
                    ConNo = 0,
                    //ConNo = double.Parse(txtConno.Text),
                    TongTien = double.Parse(txtTongtien.Text),
                    GhiChu = txtGhichu.Text
                };
                khNew.Save();

                ClearBinding();

                //Tien ve dong cuoi cung Gridview
                gvKhachHang.ClearSelection();
                int nRowIndex = gvKhachHang.Rows.Count - 1;
                gvKhachHang.Rows[nRowIndex].Selected = true;
                gvKhachHang.Columns[0].ReadOnly = true;
                gvKhachHang.FirstDisplayedScrollingRowIndex = nRowIndex;
                gvKhachHang.Refresh();
                XoaField();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow item in gvKhachHang.Rows)
                {

                    KhachHang khUpdate = new KhachHang()
                    {
                        MaKH = int.Parse(item.Cells["MaKH"].Value.ToString()),
                        TenKH = item.Cells["TenKH"].Value.ToString(),
                        DienThoai = item.Cells["DienThoai"].Value.ToString(),
                        DiaChi = item.Cells["DiaChi"].Value.ToString(),
                        CapKH = int.Parse(item.Cells["CapKH"].Value.ToString()),
                        TienNo = double.Parse(item.Cells["TienNo"].Value.ToString()),
                        DaTra = double.Parse(item.Cells["DaTra"].Value.ToString()),
                        ConNo = double.Parse(item.Cells["ConNo"].Value.ToString()),
                        TongTien = double.Parse(item.Cells["TongTien"].Value.ToString()),
                        GhiChu = item.Cells["GhiChu"].Value.ToString()
                    };
                    if (khUpdate.MaKH.ToString() == txtID.Text)
                    {
                        khUpdate.CapKH = int.Parse(txtCapKh.Text);
                        khUpdate.TenKH = txtName.Text;
                        khUpdate.DienThoai = txtPhone.Text;
                        khUpdate.DiaChi = txtAddress.Text;
                        khUpdate.TienNo = double.Parse(txtTienno.Text);
                        khUpdate.DaTra = double.Parse(txtDatra.Text);
                       // khUpdate.ConNo = double.Parse(txtConno.Text);
                        khUpdate.TongTien = double.Parse(txtTongtien.Text);
                        khUpdate.GhiChu = txtGhichu.Text;
                        khUpdate.ConNo = khUpdate.TienNo - double.Parse(txtDatra.Text);
                        khUpdate.TienNo = khUpdate.ConNo;
                        khUpdate.DaTra = 0;
                    }
                    if (khUpdate.CapKH < 0 || khUpdate.CapKH > 3)
                    {
                        MessageBox.Show("Cấp chỉ từ 1,2,3 !");
                        return;
                    }
                   
                    KhachHangController.Update(khUpdate, khUpdate.MaKH);
                    
                }
                //Clear binding component
                ClearBinding();
                XoaField(); 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = 0;
                int.TryParse(txtID.Text, out makh);
                int count = HoaDon.All().Where(hd => hd.MaKH == makh).Count();
                if (count <= 0)
                {
                    KhachHang.Delete(kh => kh.MaKH == makh);
                }
                else
                {
                    MessageBox.Show("Khách hàng còn hóa đơn. Không thể xóa !");
                }
                ClearBinding();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Ham ho tro
        private void ClearBinding()
        {
            //Xoa binding component
            //txtID.DataBindings.RemoveAt(0);
            //txtName.DataBindings.RemoveAt(0);
            //txtPhone.DataBindings.RemoveAt(0);
            //txtAddress.DataBindings.RemoveAt(0);
            //txtCapKh.DataBindings.RemoveAt(0);
            FormQuanLyKH_Load(null, null);
            MessageBox.Show("Dữ liệu được  thay đổi !");
        }

        //private void gvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //KhachHang kh = new KhachHang();
        //   // kh.

        //}

        private void gvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtID.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                this.txtName.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                this.txtPhone.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
                this.txtAddress.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                this.txtCapKh.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["CapKH"].Value.ToString();
                this.txtTienno.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["TienNo"].Value.ToString();
                this.txtDatra.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["DaTra"].Value.ToString();
                //this.txtConno.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["ConNo"].Value.ToString();
                this.txtTongtien.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();
                this.txtGhichu.Text = this.gvKhachHang.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
