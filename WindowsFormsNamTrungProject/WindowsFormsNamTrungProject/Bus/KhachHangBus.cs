using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Dao;
using NamTrungProject.Models;
using ModelDB.Data;

namespace NamTrungProject.Bus
{
    class KhachHangBus
    {
        public static List<KhachHangModel> GetAllKHModel()
        {
           return KhachHangDao.ListkhModel();
        }

        public static IQueryable<KhachHang> GetAll()
        {
            return KhachHangDao.GetAllKhachHang();
        }

        public static bool Update(KhachHang kh,int makh)
        {
            return KhachHangDao.Update(kh,makh);
        }

        public static KhachHang Find(int makh)
        {
            return KhachHangDao.Find(makh);
        }
    }
}
