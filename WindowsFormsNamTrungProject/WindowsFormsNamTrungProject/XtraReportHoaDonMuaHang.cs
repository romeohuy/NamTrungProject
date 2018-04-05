using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
namespace NamTrungProject
{
    public partial class XtraReportHoaDonMuaHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportHoaDonMuaHang(string tienmua, string tongtien, string tienno, string ghichu, string khachhang, string loinhuan,string datra,string conno)
        {
            InitializeComponent();
            cellDonGia.DataBindings.Add("Text", DataSource, "DonGia_");
            cellTenSP.DataBindings.Add("Text", DataSource, "TenSP_");
            //cellSTT.DataBindings.Add("Text", DataSource, "STT");  cellSLMua.DataBindings.Add("Text", DataSource, "SoLuong_");
            cellThanhtien.DataBindings.Add("Text", DataSource, "ThanhTien_");
            txtDVT.DataBindings.Add("Text", DataSource, "DVT_");
            txtTienno.Text = tienno;
            cellTongTien.Text = tongtien;
            cellTienMua.Text = tienmua;
            cellGhichu.Text = ghichu;
            cellDaTra.Text = datra;
            celConNo.Text = conno;
            lbkhachhang.Text = khachhang;
            xrLbLoiNhuan.Text = loinhuan;
            lbDate.Text = DateTime.UtcNow.Day + @"/" + DateTime.UtcNow.Month + @"/" + DateTime.UtcNow.Year;
        }

    }
}
