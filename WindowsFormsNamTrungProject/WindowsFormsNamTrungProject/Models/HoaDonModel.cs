using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;

namespace NamTrungProject.Models
{
    public class HoaDonModel
    {

        
        public int? MaHD { get; set; }

        public int? MaKH { get; set; }

        public String TenHoaDon { get; set; }

        public String TenNguoiMua { get; set; }

        public DateTime? NgayMua { get; set; }

        public Double? TongTien { get; set; }

        public Double? TienNo { get; set; }

        //public List<HoaDon> GetAll()
        //{
        //    return db.HoaDon.ToList();
        //}

        //public HoaDon GetHoaDon(int mahoadon)
        //{
        //    return db.HoaDon.FirstOrDefault(hd => hd.MaHD == mahoadon);
        //}


    }

    public class HoaDonModelHelper
    {

        public static HoaDonModel ParseToModel(HoaDon hoadon_,int maKh)
        {
            HoaDonModel model = new HoaDonModel
            {
                MaHD = hoadon_.MaHD,
                MaKH = maKh,
                NgayMua = hoadon_.NgayMua.Value,
                TenHoaDon = hoadon_.TenHoadon,
                TenNguoiMua = hoadon_.TenNguoiMua,
                TienNo = hoadon_.TienNo.Value,
                TongTien = hoadon_.TongTien.Value
            };
            return model;
        }


    }
}
