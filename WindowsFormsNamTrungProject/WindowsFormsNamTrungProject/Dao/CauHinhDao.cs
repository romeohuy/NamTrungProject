using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDB.Data;

namespace NamTrungProject.Dao
{
   public class CauHinhDao
    {
        public IQueryable<CauHinh> GetAll()
        {
            return CauHinh.All();
        }

        public CauHinh GetByName(string ten)
        {
            return CauHinh.All().FirstOrDefault(t => t.Ten == ten);
        }

        public bool Update(string ten,string giatri)
        {
            try
            {
                var cauhinh = CauHinh.All().FirstOrDefault(t => t.Ten.Equals(ten, StringComparison.InvariantCultureIgnoreCase));
                if (cauhinh != null)
                {
                    cauhinh.GiaTri = giatri;
                    cauhinh.Update();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
