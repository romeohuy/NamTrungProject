using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using ModelDB.Data;
using NamTrungProject.Dao;

namespace NamTrungProject.Bus
{
    class ChiTietHoaDonBus
    {
        public  ChiTietHoaDonModel ParseSP2CTHD(int maHD, SanPhamModel spModel_, double? slMua)
        {

            ChiTietHoaDonModel chitiet = new ChiTietHoaDonModel
            {
                MaHD_ = maHD,
                MaSP_ = spModel_.MaSP_,
                SoLuong_ = slMua,
                TenSP_ = spModel_.TenSP_,
                TonDau_ = spModel_.SLTon_,
                DonGia_ = spModel_.DonGia_,
                DVT_ = spModel_.DVT_,
                ThanhTien_ = Math.Round((slMua * spModel_.DonGia_).Value, 1, MidpointRounding.AwayFromZero),
                LoiNhuan_ = Math.Round((spModel_.DonGia_ - spModel_.GiaGoc_).Value, 1, MidpointRounding.AwayFromZero),
                LoiNhuanTong_ = Math.Round(((spModel_.DonGia_ - spModel_.GiaGoc_)*slMua).Value,1,MidpointRounding.AwayFromZero),
                DonGiaGoc_ = spModel_.GiaGoc_,
                STT_ = 0
            };
            return chitiet;
        }
        public ChiTietHoaDonModel ParseSP2CTHD( ChiTietHoaDon spModel_)
        {

            ChiTietHoaDonModel chitiet = new ChiTietHoaDonModel
            {
                MaHD_ = spModel_.MaHD,
                MaSP_ = spModel_.MaSP,
                SoLuong_ = spModel_.SoLuong,
                TenSP_ = spModel_.TenSP,
                TonDau_ = spModel_.TonDau,
                DonGia_ = spModel_.DonGia,
                DVT_ = spModel_.DVT,
                ThanhTien_ = spModel_.SoLuong * spModel_.DonGia,
                LoiNhuan_ = spModel_.LoiNhuan,
                LoiNhuanTong_ = spModel_.LoiNhuanTong,
                DonGiaGoc_ = spModel_.DonGiaGoc,
                STT_ = 0
            };
            return chitiet;
        }

        public static ChiTietHoaDon ParseCTModel2CTHD(int maHD, ChiTietHoaDonModel ctModel_)
        {
            
            ChiTietHoaDon chitiet = new ChiTietHoaDon
            {
                MaHD = maHD,
                MaSP = ctModel_.MaSP_.Value,
                SoLuong = ctModel_.SoLuong_,
                TenSP = ctModel_.TenSP_,
                TonDau = ctModel_.TonDau_,
                DonGia = ctModel_.DonGia_,
                DVT = ctModel_.DVT_,
                ThanhTien = ctModel_.SoLuong_ * ctModel_.DonGia_,
                LoiNhuan = ctModel_.LoiNhuan_,
                LoiNhuanTong = ctModel_.LoiNhuanTong_,
                DonGiaGoc = ctModel_.DonGiaGoc_,
                STT = ctModel_.STT_
            };
            return chitiet;
        }
        public  bool UpDateQuantity(List<ChiTietHoaDonModel> listCtHoadon,ChiTietHoaDonModel cthdInsert)
        {
            try
            {
                int count = 0;
                foreach (var item in listCtHoadon)
                {
                    if (item.MaSP_ == cthdInsert.MaSP_)
                    {
                        item.SoLuong_ += cthdInsert.SoLuong_;
                        item.ThanhTien_ += (cthdInsert.SoLuong_ * cthdInsert.DonGia_);
                        item.LoiNhuanTong_ += (cthdInsert.SoLuong_ * item.LoiNhuan_);
                        count += 1;
                    }
                    
                    
                }
                if (count == 0)
                {
                    listCtHoadon.Add(cthdInsert);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            //return listCtHoadon;
        }

        public static Double? TinhTienMua(List<ChiTietHoaDonModel> listSanPhamMua)
        {
            double? tongtienmua = 0;
            foreach (var item in listSanPhamMua)
            {
                tongtienmua += item.ThanhTien_;
            }
            return tongtienmua;
        }

        public static void UpdateTienMua(List<ChiTietHoaDonModel> listSanPhamMua)
        {
            foreach (var item in listSanPhamMua)
            {
                item.LoiNhuan_ = Math.Round((item.DonGia_ - item.DonGiaGoc_).Value,1,MidpointRounding.AwayFromZero);
                item.ThanhTien_ = Math.Round((item.SoLuong_ * item.DonGia_).Value,1,MidpointRounding.AwayFromZero);
                item.LoiNhuanTong_ = Math.Round((item.LoiNhuan_ * item.SoLuong_).Value,1,MidpointRounding.AwayFromZero);
            }
        }

        public static bool AddMulti(int maHd, List<ChiTietHoaDonModel> listCtModel)
        {
            return ChiTietHoaDonDao.AddMulti(maHd, listCtModel);
        }

        public static List<ChiTietHoaDonModel> GetAllByMaHD(int mahd)
        {
            return ChiTietHoaDonDao.GetAllByMaHD(mahd);
        }
    }
}
