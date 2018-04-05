using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamTrungProject.Models
{
    class ChiTietHoaDonModel
    {
        public int? STT_ { get; set; }
        public int? MaHD_ { get; set; }
        public int? MaSP_ { get; set; }

        public String TenSP_ { get; set; }

        public String DVT_ { get; set; }

        public Double? TonDau_ { get; set; }

        public Double? SoLuong_ { get; set; }

        public Double? DonGia_ { get; set; }

        public Double? DonGiaGoc_ { get; set; }

        public Double? ThanhTien_ { get; set; }

        public Double? LoiNhuan_ { get; set; }

        public Double? LoiNhuanTong_ { get; set; }
    }
}
