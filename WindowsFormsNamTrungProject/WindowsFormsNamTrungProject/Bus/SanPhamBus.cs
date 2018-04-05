using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamTrungProject.Models;
using NamTrungProject.Dao;
using ModelDB.Data;
namespace NamTrungProject.Bus
{
    class SanPhamBus
    {
        public List<SanPhamModel> FindContainsProc(List<SanPhamModel> listSp, string textSearch)
        {
            return listSp.Where(sp => sp.TenSP_.ToLower().Contains(textSearch.ToLower())).ToList();
        }
        public List<SanPhamModel> ParserSamPhamsToModel(int capkh,List<SanPham> list)
        {
            List<SanPhamModel> listSp;
            SanPhamDao spDao=new SanPhamDao();
            switch (capkh)
            {
                case 1 :
                    listSp = list.Select(p => new SanPhamModel
                    {
                        MaSP_ = p.MaSP,
                        TenSP_ = p.TenSP,
                        DVT_ = p.DVT,
                        SLTon_ = p.SLTon,
                        DonGia_ = p.DonGia1,
                        GiaGoc_ = p.DonGiaGoc
                    }).ToList();
                    break;
                case 2:
                    listSp = list.Select(p => new SanPhamModel
                    {
                        MaSP_ = p.MaSP,
                        TenSP_ = p.TenSP,
                        DVT_ = p.DVT,
                        SLTon_ = p.SLTon,
                        DonGia_ = p.DonGia2,
                        GiaGoc_ = p.DonGiaGoc
                    }).ToList();
                    break;
                case 3:
                    listSp = list.Select(p => new SanPhamModel
                    {
                        MaSP_ = p.MaSP,
                        TenSP_ = p.TenSP,
                        DVT_ = p.DVT,
                        SLTon_ = p.SLTon,
                        DonGia_ = p.DonGia3,
                        GiaGoc_ = p.DonGiaGoc
                    }).ToList();
                    break;
                default:
                    listSp = list.Select(p => new SanPhamModel
                    {
                        MaSP_ = p.MaSP,
                        TenSP_ = p.TenSP,
                        DVT_ = p.DVT,
                        SLTon_ = p.SLTon,
                        DonGia_ = p.DonGia1,
                        GiaGoc_ = p.DonGiaGoc
                    }).ToList();
                    break;
            }
            return listSp;
        }

        public IQueryable<SanPham> GetAll()
        {
            SanPhamDao spDao = new SanPhamDao();
            return spDao.GetAllProc();

        }

        public static bool AddSP(SanPham sp)
        {
            SanPhamDao spDao = new SanPhamDao();
           return spDao.AddProc(sp);
        }

        public static bool DeleteOne(int id)
        {
            return SanPhamDao.DeleteOne(id);
        }
    }
}
