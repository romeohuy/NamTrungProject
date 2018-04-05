using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;
namespace NamTrungProject.Dao
{
    class HoaDonDao
    {
        public static List<HoaDon> GetAll()
        {
           return HoaDon.All().OrderByDescending(t=>t.MaHD).ToList();
        }

        public static void Delete(int mahd)
        {
            HoaDon.Delete(hd=> hd.MaHD == mahd);
            ChiTietHoaDon.Delete(ct => ct.MaHD == mahd);
        }
    }
}
