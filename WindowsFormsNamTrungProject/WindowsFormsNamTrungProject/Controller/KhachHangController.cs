using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using NamTrungProject.Bus;
using ModelDB.Data;

namespace NamTrungProject.Controller
{
    class KhachHangController
    {
        public static List<KhachHangModel> GetAllKHModel()
        {
            return KhachHangBus.GetAllKHModel();
        }

        public static IQueryable<KhachHang> GetAll()
        {
            return KhachHangBus.GetAll();
        }

        public static bool Update(KhachHang kh, int makh)
        {
            return KhachHangBus.Update(kh, makh);
        }

        public static KhachHang Find(int makh)
        {
            return KhachHangBus.Find(makh);
        }
    }
}
