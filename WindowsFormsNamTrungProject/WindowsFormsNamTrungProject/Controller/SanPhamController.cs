using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using NamTrungProject.Bus;
using ModelDB.Data;

namespace NamTrungProject.Controller
{
    class SanPhamController
    {
        public List<SanPham> GetAll()
        {

            SanPhamBus spBus = new SanPhamBus();
            return spBus.GetAll().ToList();
        }
        public List<SanPhamModel> GetDataGridSanPham(int capkh,List<SanPham> list_)
        {
            SanPhamBus spBus = new SanPhamBus();
           return  spBus.ParserSamPhamsToModel(capkh,list_);
        }

        public List<SanPhamModel> FindProcs(List<SanPhamModel> listSp, string textSearch)
        {
            SanPhamBus spBus = new SanPhamBus();
            return spBus.FindContainsProc(listSp, textSearch);
        }

        public static bool AddSP(SanPham sp)
        {
           return  SanPhamBus.AddSP(sp);
        }

        public static bool DeleteOne(int id)
        {
            return SanPhamBus.DeleteOne(id);
        }
    }
}
