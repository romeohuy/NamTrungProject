using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;
using NamTrungProject.Models;
namespace NamTrungProject.Dao
{
    class KhachHangDao
    {
        public static IQueryable<KhachHang> GetAllKhachHang()
        {
            try
            {
                return KhachHang.All();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<KhachHangModel> ListkhModel()
        {
            List<KhachHangModel> listKh = new List<KhachHangModel>();
            foreach (var item in KhachHang.All().OrderBy(t=>t.TenKH))
            {
                KhachHangModel kh = new KhachHangModel()
                {
                    MaKH = item.MaKH,
                    TenKH = item.TenKH

                };
                listKh.Add(kh);
            }
            return listKh;
        }

        public static bool Update(KhachHang khUpdate, int maKh)
        {
            try
            {
                KhachHang kh = KhachHang.Find(k => k.MaKH == maKh).SingleOrDefault();
                kh.TenKH = khUpdate.TenKH;
                kh.DienThoai = khUpdate.DienThoai;
                kh.DiaChi = khUpdate.DiaChi;
                kh.CapKH = khUpdate.CapKH;
                kh.TienNo = khUpdate.TienNo;
                kh.DaTra = khUpdate.DaTra;
                kh.ConNo = khUpdate.ConNo;
                kh.TongTien = khUpdate.TongTien;
                kh.GhiChu = khUpdate.GhiChu;
                kh.Update();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static KhachHang Find(int makh)
        {
            return KhachHang.Find(kh => kh.MaKH == makh).SingleOrDefault();
        }
    }
}
