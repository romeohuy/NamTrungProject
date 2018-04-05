using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using ModelDB.Data;
using NamTrungProject.Bus;
namespace NamTrungProject.Dao
{
    class ChiTietHoaDonDao
    {
        public static bool AddMulti(int maHd,List<ChiTietHoaDonModel> listCtModel)
        {
            try
            {
                foreach (ChiTietHoaDonModel item in listCtModel)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct = ChiTietHoaDonBus.ParseCTModel2CTHD(maHd, item);
                    ct.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<ChiTietHoaDonModel> GetAllByMaHD(int mahd)
        {
            ChiTietHoaDonBus bus=new ChiTietHoaDonBus();
            List<ChiTietHoaDonModel> listCt = new List<ChiTietHoaDonModel>();
            foreach (ChiTietHoaDon item in ChiTietHoaDon.All().Where(h=>h.MaHD == mahd))
            {
                listCt.Add(bus.ParseSP2CTHD(item));
            }
            return listCt;
        }
    }
}
