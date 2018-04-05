using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelDB.Data;
using NamTrungProject.Controller;
using NamTrungProject.Dao;
using PagedList;

namespace NamTrungProject
{
    public partial class FormThongKe : Form
    {
        double cauhinh1 = 0.0;
        double cauhinh2 = 0.0;
        double cauhinh3 = 0.0;
        
        IPagedList<SanPham> listSP;
        private List<SanPham> allSp;
        private int pageNumber = 1;
        private double slTon = double.MinValue;
        private string search = "";
        SanPhamController spCtr = new SanPhamController();
        CauHinhDao cauHinhDao = new CauHinhDao();
        public FormThongKe()
        {
            allSp = spCtr.GetAll();
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

        private IPagedList<SanPham> GetPageListSanPham(int pageNumber = 1,int pageSize = 20)
        {
            if (Math.Abs(slTon - double.MinValue) > 0)
            {
                
                if (!string.IsNullOrEmpty(search))
                {
                    return allSp.Where(t=> t.SLTon <= slTon && t.TenSP.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToPagedList(pageNumber, pageSize);
                }
                else
                {
                    return allSp.Where(t => t.SLTon <= slTon).ToPagedList(pageNumber, pageSize);
                }
            }
            if (string.IsNullOrEmpty(search))
            {
                return allSp.ToPagedList(pageNumber, pageSize);
            }
            return allSp.Where(t=>t.TenSP.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToPagedList(pageNumber, pageSize);
        }
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            listSP =  GetPageListSanPham();
            btnPrew.Enabled = listSP.HasPreviousPage;
            btnNext.Enabled = listSP.HasNextPage;
            BindingSource bd = new BindingSource() { DataSource = listSP.ToList() };
            dataGridView1.DataSource = bd;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Width = 80;
            this.dataGridView1.Columns[2].Width =300;
            lbPageNumber.Text = string.Format($"Trang {pageNumber}/{listSP.PageCount}");
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pageNumber = 1;
                if (!double.TryParse(txtSoLuong.Text, out slTon))
                {
                    slTon = double.MinValue;
                }
                FormThongKe_Load(sender,e);
            }
            catch (System.Exception)
            {
                // ignored
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (var item in listSP)
            {
                try
                {
                    SanPham sp = SanPham.Find(k => k.MaSP == item.MaSP).SingleOrDefault();
                    sp.TenSP = item.TenSP;
                    sp.SLDau = item.SLDau;
                    sp.SLTon = item.SLTon;
                    sp.DVT = item.DVT;
                    sp.DonGiaGoc = item.DonGiaGoc;
                    sp.DonGia3 = item.DonGia3;
                    sp.DonGia2 = item.DonGia2;
                    sp.DonGia1 = item.DonGia1;
                    sp.Update();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            MessageBox.Show(@"Cập nhật dữ liệu xong");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search = txtSearch.Text;
            FormThongKe_Load(sender,e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNewSP frmNew = new AddNewSP();
            frmNew.ShowDialog();
            FormThongKe_Load(sender, e);
            dataGridView1.ClearSelection();
            int nRowIndex = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[nRowIndex].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46 || e.KeyCode.ToString() == "Delete")
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int vitri = dataGridView1.CurrentRow.Index;
                    int id = 0;
                    int.TryParse(dataGridView1.Rows[vitri].Cells["MaSP"].Value.ToString(), out id);
                    DialogResult result = MessageBox.Show(@"Bạn có muốn xóa sp này", @"Xóa sản phẩm ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        if (SanPhamController.DeleteOne(id))
                        {
                            MessageBox.Show(@"Xóa thành công");
                            FormThongKe_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show(@"Lỗi");
                        }

                    }
                }
            }
        }

        private void btnPrew_Click(object sender, EventArgs e)
        {
            if (listSP.HasPreviousPage)
            {
                listSP = GetPageListSanPham(--pageNumber);
                btnPrew.Enabled = listSP.HasPreviousPage;
                btnNext.Enabled = listSP.HasNextPage;
                BindingSource bd = new BindingSource() { DataSource = listSP };
                dataGridView1.DataSource = bd;
                lbPageNumber.Text = string.Format($"Trang {pageNumber}/{listSP.PageCount}");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (listSP.HasNextPage)
            {
                listSP = GetPageListSanPham(++pageNumber);
                btnPrew.Enabled = listSP.HasPreviousPage;
                btnNext.Enabled = listSP.HasNextPage;
                BindingSource bd = new BindingSource() { DataSource = listSP };
                dataGridView1.DataSource = bd;
                lbPageNumber.Text = string.Format($"Trang {pageNumber}/{listSP.PageCount}");
            }
        }
    }
}
