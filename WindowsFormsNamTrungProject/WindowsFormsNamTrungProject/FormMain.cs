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
using ModelDB.Data;
using System.Globalization;
using System.Configuration;
using DevExpress.XtraReports.UI;
using NamTrungProject.Dao;

namespace NamTrungProject
{
    public partial class FormMain : Form
    {
        int maHD = 0;
        string ghichu = null;
        private List<SanPhamModel> listSp = new List<SanPhamModel>();
        //ChiTietHoaDonModel ctHoaDonInsert = new ChiTietHoaDonModel();
        private SanPhamController spCtr = new SanPhamController();
        private List<ChiTietHoaDonModel> listCtHoaDon = new List<ChiTietHoaDonModel>();
        private List<SanPham> list_ = new List<SanPham>();
        KhachHang kh = null;
        public FormMain()
        {
            InitializeComponent();
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 15)
            {
                MessageBox.Show(@"Hết hạn sử dụng phần mềm");
                this.Close();
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            
            BindingSource dbSouce = new BindingSource() { DataSource = KhachHangController.GetAllKHModel() };
            cboKhachHang.DataSource = dbSouce;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
            list_ = SanPham.All().ToList();
            listSp = spCtr.GetDataGridSanPham(int.Parse(cboCapKH.Text), list_);
            BindingSource bdSource = new BindingSource() { DataSource = listSp };
            gvSanPham.DataSource = bdSource;
            cboKhachHang.Text = "";
            cboCapKH.SelectedIndex = 2;
        }

        private void gvSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var dataGridViewRow = this.gvSanPham.CurrentRow;
                if (dataGridViewRow != null) dataGridViewRow.Selected = true;
                e.Handled = true;
                this.txtSLMua.Clear();
                this.txtSLMua.Focus();
            }
        }

        private void txtSLMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            double slmua = 0;
            if (e.KeyChar == 13)
            {
                if (!Double.TryParse(txtSLMua.Text, out slmua))
                {
                    MessageBox.Show(@"Số lượng nhập không đúng !");
                    txtSLMua.ResetText();
                    return;
                }
                else
                {
                    try
                    {
                        if (gvSanPham.CurrentRow == null)
                        {
                            MessageBox.Show(@"Bạn chưa chọn sản phẩm !");
                            return;
                        }
                        ChiTietHoaDonController ctHdCtr = new ChiTietHoaDonController();
                        int masp_ = int.Parse(gvSanPham.CurrentRow.Cells[0].Value.ToString());
                        SanPhamModel spModel = listSp.FirstOrDefault(sp => sp.MaSP_ == masp_);
                        ctHdCtr.AddToChiTietHoaDon(maHD, spModel, slmua, listCtHoaDon);
                        //Sap xep lai list hoa don
                        for (int i = 1; i <= listCtHoaDon.Count; i++)
                        {
                            listCtHoaDon[i - 1].STT_ = i;
                            string[] ten = listCtHoaDon[i - 1].TenSP_.Split(';');
                            if (ten.Count() > 1)
                            {
                                listCtHoaDon[i - 1].TenSP_ = ten[0];
                            }
                        }
                        BindingSource bdChitiethoadon = new BindingSource() { DataSource = listCtHoaDon };
                        gvChiTietHoaDon.DataSource = bdChitiethoadon;
                        gvChiTietHoaDon.ClearSelection();
                        int nRowIndex = gvChiTietHoaDon.Rows.Count - 1;
                        gvChiTietHoaDon.Rows[nRowIndex].Selected = true;
                        gvChiTietHoaDon.FirstDisplayedScrollingRowIndex = nRowIndex;
                        gvChiTietHoaDon.Refresh();
                        CapNhatTextFieldTinhTien();
                        txtDatra_TextChanged(null, null);
                    }
                    catch (System.Exception ex)
                    {

                    }
                }

                this.txtSearch.Clear();
                this.txtSearch.Focus();
            }
        }

        private void cboCapKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bdSource = new BindingSource() { DataSource = spCtr.GetDataGridSanPham(int.Parse(cboCapKH.Text), list_) };
            this.gvSanPham.DataSource = bdSource;
            listSp  = spCtr.GetDataGridSanPham(int.Parse(cboCapKH.Text),list_);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            BindingSource bdSource = new BindingSource() { DataSource = spCtr.FindProcs(listSp, txtSearch.Text) };
            this.gvSanPham.DataSource = bdSource;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Down" || e.KeyValue == 13)
            {
                this.gvSanPham.Focus();
            }
        }




        private void gvChiTietHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (listCtHoaDon.Count != 0)
                {
                    ChiTietHoaDonController.UpdateTienMua(listCtHoaDon);
                    BindingSource bdChitiethoadon = new BindingSource() { DataSource = listCtHoaDon };
                    gvChiTietHoaDon.DataSource = bdChitiethoadon;
                    CapNhatTextFieldTinhTien();
                }
                else
                    return;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ !");
            }

        }

        ////////////////////////Event For Tool Bar Header ///////////////////

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe formThongke = new FormThongKe();
            formThongke.ShowDialog();
            FormMain_Load(null, null);
        }

        private void btnQuanliKH_Click(object sender, EventArgs e)
        {
            FormQuanLyKH formKh = new FormQuanLyKH();
            formKh.ShowDialog();
            //if (formKh.IsDisposed)
            //{
            //    BindingSource dbSouce = new BindingSource() { DataSource = KhachHangController.GetAllKHModel() };
            //    cboKhachHang.DataSource = dbSouce;
            //    cboKhachHang.DisplayMember = "TenKH";
            //    cboKhachHang.ValueMember = "MaKH";
            //}
            BindingSource dbSouce = new BindingSource() { DataSource = KhachHangController.GetAllKHModel() };
            cboKhachHang.DataSource = dbSouce;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int makh = 0;
                int.TryParse(cboKhachHang.SelectedValue.ToString(), out makh);
                kh = KhachHangController.Find(makh);
               
                if (kh != null)
                {
                    cboCapKH.SelectedIndex = kh.CapKH.Value - 1;
                    txtTienNo.Text = (kh.TienNo - kh.DaTra).ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ////////////////////////End Event For Tool Bar Header ///////////////////

        private void CapNhatTextFieldTinhTien()
        {
            if (listCtHoaDon.Count > 0)
            {
                double tienno = 0;
                if (double.TryParse(txtTienNo.Text, out tienno))
                {
                    //Cap nhat textfield tinh tien
                }
                else
                {
                    MessageBox.Show("Số tiền nhập không đúng !");
                    txtTienNo.Focus();
                    return;
                }
                double? tienmua = ChiTietHoaDonController.TinhTienMua(listCtHoaDon);
                this.lbTienmua.Text = tienmua.ToString();
                double? tongtien = tienno + tienmua;
                
                lbThanhTien.Text = tongtien.ToString();
                txtDatra_TextChanged(null,null);
            }
            //  gvSanPham.Refresh();
            // gvChiTietHoaDon.RefreshEdit();
            txtSearch.Clear();
            //txtSearch.Focus();
        }

        private void txtTienNo_Leave(object sender, EventArgs e)
        {

            CapNhatTextFieldTinhTien();
        }

        private void gvChiTietHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46 || e.KeyCode.ToString() == "Delete")
            {
                int vitri = gvChiTietHoaDon.CurrentRow.Index;
                List<ChiTietHoaDonModel> listTemp = new List<ChiTietHoaDonModel>();
                listTemp.AddRange(listCtHoaDon);
                listTemp.RemoveAt(vitri);
                listCtHoaDon.Clear();
                listCtHoaDon.AddRange(listTemp);
                BindingSource bdSource = new BindingSource() { DataSource = listCtHoaDon };
                gvChiTietHoaDon.DataSource = bdSource;
                //MessageBox.Show(vi);
                //listCtHoaDon.RemoveAt(gvChiTietHoaDon.CurrentRow.Index);
                CapNhatTextFieldTinhTien();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
              KhachHang khOpen =  KhachHangController.Find(int.Parse(cboKhachHang.SelectedValue.ToString()));
                HoaDon hd = new HoaDon()
                {
                    MaKH = int.Parse(cboKhachHang.SelectedValue.ToString()),
                    NgayMua = DateTime.Now,
                    TenHoadon = cboKhachHang.Text + "_" + lbThanhTien.Text + "_" + khOpen.ConNo,
                    TenNguoiMua = cboKhachHang.Text,
                    TienNo = khOpen.ConNo,
                    TongTien = double.Parse(lbThanhTien.Text)
                };
                hd.Save();

                if (ChiTietHoaDonController.AddMulti(hd.MaHD, listCtHoaDon))
                {
                    MessageBox.Show("Lưu thành công !");
                }
                else
                    MessageBox.Show("Lỗi !");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnHoaDonMoi_Click(object sender, EventArgs e)
        {
            listCtHoaDon.Clear();
            gvChiTietHoaDon.DataSource = listCtHoaDon;
            CapNhatTextFieldTinhTien();
            lbTienmua.Text = "0";
            lbThanhTien.Text = "0";
            txtTienNo.Text = "0";
            txtSLMua.Text = "";
            cboKhachHang.Text = "";
            txtDatra.Text = "0";
            txtConNo.Text = "0";
            cboCapKH.SelectedIndex = 2;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {


                double tienmua = listCtHoaDon.Sum(t => t.ThanhTien_).Value * 1000;
                double tongtien = tienmua + double.Parse(txtTienNo.Text) * 1000;
                double tienno = double.Parse(txtTienNo.Text);
                double datra = double.Parse(txtDatra.Text);
                double tienconno= double.Parse(txtConNo.Text);
                double loinhuanRp = listCtHoaDon.Sum(ln => ln.LoiNhuanTong_).Value;
                CapNhatTienKhachHang(listCtHoaDon.Sum(t => t.ThanhTien_).Value , datra, tienconno);
                //cap nhat so luong ton
                SanPhamDao spDao = new SanPhamDao();
                for (int i = 1; i <= listCtHoaDon.Count; i++)
                {
                    var soLuong = listCtHoaDon[i - 1].SoLuong_;
                    if (soLuong != null)
                    {
                        var maSp = listCtHoaDon[i - 1].MaSP_;
                        if (maSp != null)
                            spDao.UpdateProcMua(soLuong.Value, maSp.Value);
                    }
                }
                list_ = SanPham.All().ToList();
                listSp = spCtr.GetDataGridSanPham(int.Parse(cboCapKH.Text), list_);
                BindingSource bdSource = new BindingSource() { DataSource = listSp };
                gvSanPham.DataSource = bdSource;
                txtDatra.Text = "0";txtConNo.Text = "0";
                CultureInfo vietnam = new CultureInfo(1066);
                CultureInfo usa = new CultureInfo("en-US");
                NumberFormatInfo nfi = usa.NumberFormat;
                nfi = (NumberFormatInfo)nfi.Clone();
                NumberFormatInfo vnfi = vietnam.NumberFormat;
                nfi.CurrencySymbol = vnfi.CurrencySymbol;
                nfi.CurrencyNegativePattern = vnfi.CurrencyNegativePattern;
                nfi.CurrencyPositivePattern = vnfi.CurrencyPositivePattern;
                XtraReportHoaDonMuaHang report = new XtraReportHoaDonMuaHang(tienmua.ToString("c0", nfi), tongtien.ToString("c0", nfi), (tienno*1000).ToString("c0", nfi), ghichu, cboKhachHang.Text, loinhuanRp.ToString(),(datra*1000).ToString("c0",nfi),(tienconno*1000).ToString("c0",nfi));

                // BindingSource bdChitiethoadon = new BindingSource() { DataSource = listCtHoaDon };
                // gvChiTietHoaDon.DataSource = bdChitiethoadon;
                report.DataSource = listCtHoaDon;
                report.ShowRibbonPreview();
                report.ExportOptions.Pdf.DocumentOptions.Title = cboKhachHang.Text + lbTienmua.Text + txtDatra.Text + loinhuanRp;

                string pathSave = ConfigurationManager.AppSettings["SaveOrder"];
                report.Print();
                report.ExportToPdf(pathSave + cboKhachHang.Text + "_" + lbTienmua.Text + "_" + txtDatra.Text + "_" + loinhuanRp + ".pdf");
                //InitGrid();
                //txtTienNo.Text = kh.TienNo.ToString();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(@"Chưa chọn hóa đơn");
            }

        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            FormGhiChu frmGhichu = new FormGhiChu();
            frmGhichu.ShowDialog();
            if (frmGhichu.IsDisposed)
            {
                ghichu = frmGhichu.ghichu_;
            }
        }

        private void gvChiTietHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //gvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Không hợp lệ ";
            MessageBox.Show("Dữ liệu không hợp lệ !");
        }

        private void btnOpenOrder_Click(object sender, EventArgs e)
        {
            FormHoaDon frmHD = new FormHoaDon();
            frmHD.ShowDialog();
            if (frmHD.IsDisposed)
            {
                //DataRow row = frmHD.row;
                int maHD = frmHD.maHD;
                int maKh = frmHD.maKH;
                kh = KhachHang.SingleOrDefault(t=>t.MaKH == maKh);
                txtTienNo.Text = frmHD.tienno_.ToString(CultureInfo.InvariantCulture);
                lbTienmua.Text = (frmHD.tongtien_ - frmHD.tienno_).ToString(CultureInfo.InvariantCulture);
                lbThanhTien.Text = frmHD.tongtien_.ToString(CultureInfo.InvariantCulture);
                List<ChiTietHoaDonModel> listNew = new List<ChiTietHoaDonModel>();
                listCtHoaDon = listNew;
                listCtHoaDon.AddRange(ChiTietHoaDonController.GetAllByMaHD(maHD));
                //Cap nhat so thu tu 
                for (int i = 1; i <= listCtHoaDon.Count; i++)
                {
                    listCtHoaDon[i - 1].STT_ = i;
                    string[] ten = listCtHoaDon[i - 1].TenSP_.Split(';');
                    if (ten.Count() > 1)
                    {
                        listCtHoaDon[i - 1].TenSP_ = ten[0];
                    }
                }
                BindingSource bdSource = new BindingSource() { DataSource = listCtHoaDon };
                gvChiTietHoaDon.DataSource = bdSource;
                gvChiTietHoaDon.Refresh();
                cboKhachHang.Text = kh.TenKH;
                if (kh.CapKH != null) cboCapKH.Text = kh.CapKH.Value.ToString();
            }
            CapNhatTextFieldTinhTien();
        }
        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            FormCauHinh frmCH = new FormCauHinh();
            frmCH.ShowDialog();
            FormMain_Load(null, null);
        }
        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            ThemSP formThem = new ThemSP();
            formThem.ShowDialog();
            if (formThem.IsDisposed && formThem.slmua > 0)
            {
                ChiTietHoaDonModel ctModel = new ChiTietHoaDonModel();
                ctModel.DonGia_ = formThem.dongia;
                ctModel.TenSP_ = formThem.tensp;
                ctModel.SoLuong_ = formThem.slmua;
                ctModel.DonGiaGoc_ = formThem.dongiagoc;
                ctModel.DVT_ = formThem.dvt;
                ctModel.DonGia_ = formThem.dongia;
                ctModel.LoiNhuan_ = formThem.dongia - formThem.dongiagoc;
                ctModel.LoiNhuanTong_ = (formThem.dongia - formThem.dongiagoc)*formThem.slmua;
                ctModel.ThanhTien_ = formThem.slmua * formThem.dongia;
                ctModel.MaHD_ = this.maHD;
                ctModel.MaSP_ = 0;
                ctModel.STT_ = 0;
                ctModel.TonDau_ = 0;
                listCtHoaDon.Add(ctModel);
                for (int i = 1; i <= listCtHoaDon.Count; i++)
                {
                    listCtHoaDon[i - 1].STT_ = i;
                    string[] ten = listCtHoaDon[i - 1].TenSP_.Split(';');
                    if (ten.Count() > 1)
                    {
                        listCtHoaDon[i - 1].TenSP_ = ten[0];
                    }
                }
                BindingSource bdChitiethoadon = new BindingSource() { DataSource = listCtHoaDon };
                gvChiTietHoaDon.DataSource = bdChitiethoadon;
            }
            CapNhatTextFieldTinhTien();
        }

        private void CapNhatTienKhachHang(double tienmua,double tientra,double tiencon)
        {
            KhachHang khUpdate = KhachHang.Find(k => k.MaKH == kh.MaKH).FirstOrDefault();
            if (khUpdate != null)
            {
                khUpdate.TienNo = tiencon;
                khUpdate.DaTra = 0;
                khUpdate.ConNo = tiencon;
                khUpdate.TongTien += tienmua;
                khUpdate.Update();
            }

            //FormMain_Load(null, null);
        }

        private void txtDatra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tientra = 0;
                if (double.TryParse(txtDatra.Text, out tientra))
                {
                    double? sum = 0;
                    foreach (var t in listCtHoaDon)
                    {
                        var d = t.ThanhTien_;
                        if (d.HasValue) sum += d.Value;
                    }

                    Double tienmua = sum.Value;
                     Double tongtien = tienmua + double.Parse(txtTienNo.Text);
                    txtConNo.Text = (tongtien- tientra).ToString(CultureInfo.InvariantCulture);
                }
                else
                    MessageBox.Show(@"Giá trị không hợp lệ !");
            }
            catch (Exception)
            {

                return;
            }
        }

       

        //private void gvChiTietHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    try
        //    {
        //        double soluong = 0;
        //        double thanhtien = 0;
        //        double loinhuan = 0;
        //        double loinhuantong = 0;
        //        double.TryParse(gvChiTietHoaDon.Rows[e.RowIndex].Cells["SoLuong_"].ToString(),out soluong);
        //        double.TryParse(gvChiTietHoaDon.Rows[e.RowIndex].Cells["ThanhTien_"].ToString(), out thanhtien);
        //        double.TryParse(gvChiTietHoaDon.Rows[e.RowIndex].Cells["LoiNhuan_"].ToString(), out loinhuan);
        //        double.TryParse(gvChiTietHoaDon.Rows[e.RowIndex].Cells["LOiNhuanTong_"].ToString(), out loinhuantong);
        //        ChiTietHoaDonModel model = new ChiTietHoaDonModel() {
        //            STT_ = 0,
        //            TenSP_ = gvChiTietHoaDon.Rows[e.RowIndex].Cells["TenSP"].ToString(),
        //            DVT_ = gvChiTietHoaDon.Rows[e.RowIndex].Cells["DVT"].ToString(),
        //            TonDau_ = 0,
        //            MaHD_ = 0,
        //            MaSP_ = 0,
        //            SoLuong_ = soluong,
        //            ThanhTien_ = thanhtien,
        //            LoiNhuan_ = loinhuan,
        //            LoiNhuanTong_ = loinhuantong
        //        };
        //        listCtHoaDon.Add(model);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


    }
}
