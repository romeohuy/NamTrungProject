using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using NamTrungProject.Bus;

namespace NamTrungProject.Controller
{
    class ChiTietHoaDonController
    {
        public bool AddToChiTietHoaDon(int maHD,SanPhamModel spModel,double? slMua,List<ChiTietHoaDonModel> listSp )
        {
            try
            {
                ChiTietHoaDonBus ctBus = new ChiTietHoaDonBus();
                ChiTietHoaDonModel ct = ctBus.ParseSP2CTHD(maHD, spModel, slMua);
                ctBus.UpDateQuantity(listSp, ct);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static Double? TinhTienMua(List<ChiTietHoaDonModel> listCtHD)
        {
           return ChiTietHoaDonBus.TinhTienMua(listCtHD);
        }

        public static void UpdateTienMua(List<ChiTietHoaDonModel> listCtHD)
        {
            ChiTietHoaDonBus.UpdateTienMua(listCtHD);
        }

        public static bool AddMulti(int maHd, List<ChiTietHoaDonModel> listCtModel)
        {
            return ChiTietHoaDonBus.AddMulti(maHd, listCtModel);
        }

        public static List<ChiTietHoaDonModel> GetAllByMaHD(int mahd)
        {
            return ChiTietHoaDonBus.GetAllByMaHD(mahd);
        }
    }
}
