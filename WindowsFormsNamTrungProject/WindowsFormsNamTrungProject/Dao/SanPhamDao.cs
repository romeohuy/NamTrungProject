using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;
namespace NamTrungProject.Dao
{
    class SanPhamDao
    {
        public IQueryable<SanPham> GetAllProc()
        {
            return SanPham.All();
        }

        public IQueryable<SanPham> ThongKe(double? soluong)
        {
            return SanPham.All().Where(sp => sp.SLTon < soluong);
        }

        public SanPham FindProc(int id)
        {
            return SanPham.Find(sp => sp.MaSP == id).FirstOrDefault();
        }

        public bool UpdateProcMua(double soluongmua, int id)
        {
            try
            {
                SanPham spUpdate = SanPham.Find(s => s.MaSP == id).FirstOrDefault();
                double slton = spUpdate.SLTon.Value;
                spUpdate.SLTon = slton - soluongmua;
                spUpdate.Update();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateProc(SanPham sp, int id)
        {
            try
            {
                SanPham spUpdate = SanPham.Find(s => s.MaSP == id).FirstOrDefault();
                spUpdate.TenSP = sp.TenSP;
                spUpdate.SLDau = sp.SLDau;
                spUpdate.SLTon = sp.SLTon;
                spUpdate.DVT = sp.DVT;
                spUpdate.DonGia1 = sp.DonGia1;
                spUpdate.DonGia2 = sp.DonGia2;
                spUpdate.DonGia3 = sp.DonGia3;
                spUpdate.DonGiaGoc = sp.DonGiaGoc;
                spUpdate.Update();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool DeleteOne(int id)
        {
            try
            {
                SanPham.Delete(sp => sp.MaSP == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddProc(SanPham sp)
        {
            try
            {
                SanPham spNew = new SanPham
                {
                    TenSP = sp.TenSP,
                    SLDau = sp.SLDau,
                    SLTon = sp.SLTon,
                    DVT = sp.DVT,
                    DonGia1 = sp.DonGia1,
                    DonGia2 = sp.DonGia2,
                    DonGia3 = sp.DonGia3,
                    DonGiaGoc = sp.DonGiaGoc
                };
                spNew.Save();
                return true;
            }
            catch (Exception exception)
            {

                return false;
            }
            
        }

       
    }
}
