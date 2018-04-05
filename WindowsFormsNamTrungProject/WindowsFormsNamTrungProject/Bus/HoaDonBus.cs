using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;
using NamTrungProject.Dao;

namespace NamTrungProject.Bus
{
    class HoaDonBus
    {
        public static List<HoaDon> GetAll()
        {
            return HoaDonDao.GetAll();
        }
    }
}
