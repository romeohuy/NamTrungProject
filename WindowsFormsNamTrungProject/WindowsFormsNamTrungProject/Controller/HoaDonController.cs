using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;
using NamTrungProject.Dao;

namespace NamTrungProject.Controller
{
    class HoaDonController
    {
        public static List<HoaDon> GetAll()
        {
            return HoaDonDao.GetAll();
        }

        public static void Delete(int mahd)
        {
            HoaDonDao.Delete(mahd);
        }
    }
}
