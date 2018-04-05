


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace ModelDB.Data {
	
        /// <summary>
        /// Table: SanPham
        /// Primary Key: MaSP
        /// </summary>

        public class SanPhamTable: DatabaseTable {
            
            public SanPhamTable(IDataProvider provider):base("SanPham",provider){
                ClassName = "SanPham";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MaSP", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TenSP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("DVT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("SLDau", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SLTon", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGiaGoc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGia1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGia2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGia3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MaSP{
                get{
                    return this.GetColumn("MaSP");
                }
            }
				
   			public static string MaSPColumn{
			      get{
        			return "MaSP";
      			}
		    }
            
            public IColumn TenSP{
                get{
                    return this.GetColumn("TenSP");
                }
            }
				
   			public static string TenSPColumn{
			      get{
        			return "TenSP";
      			}
		    }
            
            public IColumn DVT{
                get{
                    return this.GetColumn("DVT");
                }
            }
				
   			public static string DVTColumn{
			      get{
        			return "DVT";
      			}
		    }
            
            public IColumn SLDau{
                get{
                    return this.GetColumn("SLDau");
                }
            }
				
   			public static string SLDauColumn{
			      get{
        			return "SLDau";
      			}
		    }
            
            public IColumn SLTon{
                get{
                    return this.GetColumn("SLTon");
                }
            }
				
   			public static string SLTonColumn{
			      get{
        			return "SLTon";
      			}
		    }
            
            public IColumn DonGiaGoc{
                get{
                    return this.GetColumn("DonGiaGoc");
                }
            }
				
   			public static string DonGiaGocColumn{
			      get{
        			return "DonGiaGoc";
      			}
		    }
            
            public IColumn DonGia1{
                get{
                    return this.GetColumn("DonGia1");
                }
            }
				
   			public static string DonGia1Column{
			      get{
        			return "DonGia1";
      			}
		    }
            
            public IColumn DonGia2{
                get{
                    return this.GetColumn("DonGia2");
                }
            }
				
   			public static string DonGia2Column{
			      get{
        			return "DonGia2";
      			}
		    }
            
            public IColumn DonGia3{
                get{
                    return this.GetColumn("DonGia3");
                }
            }
				
   			public static string DonGia3Column{
			      get{
        			return "DonGia3";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: CauHinh
        /// Primary Key: Id
        /// </summary>

        public class CauHinhTable: DatabaseTable {
            
            public CauHinhTable(IDataProvider provider):base("CauHinh",provider){
                ClassName = "CauHinh";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Ten", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("GiaTri", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Ten{
                get{
                    return this.GetColumn("Ten");
                }
            }
				
   			public static string TenColumn{
			      get{
        			return "Ten";
      			}
		    }
            
            public IColumn GiaTri{
                get{
                    return this.GetColumn("GiaTri");
                }
            }
				
   			public static string GiaTriColumn{
			      get{
        			return "GiaTri";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: KhachHang
        /// Primary Key: MaKH
        /// </summary>

        public class KhachHangTable: DatabaseTable {
            
            public KhachHangTable(IDataProvider provider):base("KhachHang",provider){
                ClassName = "KhachHang";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MaKH", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TenKH", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("DienThoai", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("DiaChi", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("CapKH", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TienNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DaTra", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ConNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TongTien", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GhiChu", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823
                });
                    
                
                
            }

            public IColumn MaKH{
                get{
                    return this.GetColumn("MaKH");
                }
            }
				
   			public static string MaKHColumn{
			      get{
        			return "MaKH";
      			}
		    }
            
            public IColumn TenKH{
                get{
                    return this.GetColumn("TenKH");
                }
            }
				
   			public static string TenKHColumn{
			      get{
        			return "TenKH";
      			}
		    }
            
            public IColumn DienThoai{
                get{
                    return this.GetColumn("DienThoai");
                }
            }
				
   			public static string DienThoaiColumn{
			      get{
        			return "DienThoai";
      			}
		    }
            
            public IColumn DiaChi{
                get{
                    return this.GetColumn("DiaChi");
                }
            }
				
   			public static string DiaChiColumn{
			      get{
        			return "DiaChi";
      			}
		    }
            
            public IColumn CapKH{
                get{
                    return this.GetColumn("CapKH");
                }
            }
				
   			public static string CapKHColumn{
			      get{
        			return "CapKH";
      			}
		    }
            
            public IColumn TienNo{
                get{
                    return this.GetColumn("TienNo");
                }
            }
				
   			public static string TienNoColumn{
			      get{
        			return "TienNo";
      			}
		    }
            
            public IColumn DaTra{
                get{
                    return this.GetColumn("DaTra");
                }
            }
				
   			public static string DaTraColumn{
			      get{
        			return "DaTra";
      			}
		    }
            
            public IColumn ConNo{
                get{
                    return this.GetColumn("ConNo");
                }
            }
				
   			public static string ConNoColumn{
			      get{
        			return "ConNo";
      			}
		    }
            
            public IColumn TongTien{
                get{
                    return this.GetColumn("TongTien");
                }
            }
				
   			public static string TongTienColumn{
			      get{
        			return "TongTien";
      			}
		    }
            
            public IColumn GhiChu{
                get{
                    return this.GetColumn("GhiChu");
                }
            }
				
   			public static string GhiChuColumn{
			      get{
        			return "GhiChu";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: ChiTietHoaDon
        /// Primary Key: MaChiTiet
        /// </summary>

        public class ChiTietHoaDonTable: DatabaseTable {
            
            public ChiTietHoaDonTable(IDataProvider provider):base("ChiTietHoaDon",provider){
                ClassName = "ChiTietHoaDon";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MaChiTiet", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MaHD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MaSP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("STT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TenSP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("DVT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("SoLuong", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGia", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ThanhTien", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TonDau", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LoiNhuan", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LoiNhuanTong", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DonGiaGoc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MaChiTiet{
                get{
                    return this.GetColumn("MaChiTiet");
                }
            }
				
   			public static string MaChiTietColumn{
			      get{
        			return "MaChiTiet";
      			}
		    }
            
            public IColumn MaHD{
                get{
                    return this.GetColumn("MaHD");
                }
            }
				
   			public static string MaHDColumn{
			      get{
        			return "MaHD";
      			}
		    }
            
            public IColumn MaSP{
                get{
                    return this.GetColumn("MaSP");
                }
            }
				
   			public static string MaSPColumn{
			      get{
        			return "MaSP";
      			}
		    }
            
            public IColumn STT{
                get{
                    return this.GetColumn("STT");
                }
            }
				
   			public static string STTColumn{
			      get{
        			return "STT";
      			}
		    }
            
            public IColumn TenSP{
                get{
                    return this.GetColumn("TenSP");
                }
            }
				
   			public static string TenSPColumn{
			      get{
        			return "TenSP";
      			}
		    }
            
            public IColumn DVT{
                get{
                    return this.GetColumn("DVT");
                }
            }
				
   			public static string DVTColumn{
			      get{
        			return "DVT";
      			}
		    }
            
            public IColumn SoLuong{
                get{
                    return this.GetColumn("SoLuong");
                }
            }
				
   			public static string SoLuongColumn{
			      get{
        			return "SoLuong";
      			}
		    }
            
            public IColumn DonGia{
                get{
                    return this.GetColumn("DonGia");
                }
            }
				
   			public static string DonGiaColumn{
			      get{
        			return "DonGia";
      			}
		    }
            
            public IColumn ThanhTien{
                get{
                    return this.GetColumn("ThanhTien");
                }
            }
				
   			public static string ThanhTienColumn{
			      get{
        			return "ThanhTien";
      			}
		    }
            
            public IColumn TonDau{
                get{
                    return this.GetColumn("TonDau");
                }
            }
				
   			public static string TonDauColumn{
			      get{
        			return "TonDau";
      			}
		    }
            
            public IColumn LoiNhuan{
                get{
                    return this.GetColumn("LoiNhuan");
                }
            }
				
   			public static string LoiNhuanColumn{
			      get{
        			return "LoiNhuan";
      			}
		    }
            
            public IColumn LoiNhuanTong{
                get{
                    return this.GetColumn("LoiNhuanTong");
                }
            }
				
   			public static string LoiNhuanTongColumn{
			      get{
        			return "LoiNhuanTong";
      			}
		    }
            
            public IColumn DonGiaGoc{
                get{
                    return this.GetColumn("DonGiaGoc");
                }
            }
				
   			public static string DonGiaGocColumn{
			      get{
        			return "DonGiaGoc";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: LuuHoaDon
        /// Primary Key: MaHD
        /// </summary>

        public class LuuHoaDonTable: DatabaseTable {
            
            public LuuHoaDonTable(IDataProvider provider):base("LuuHoaDon",provider){
                ClassName = "LuuHoaDon";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MaHD", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TenHoaDon", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 150
                });

                Columns.Add(new DatabaseColumn("MoTa", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("CapKH", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MaHD{
                get{
                    return this.GetColumn("MaHD");
                }
            }
				
   			public static string MaHDColumn{
			      get{
        			return "MaHD";
      			}
		    }
            
            public IColumn TenHoaDon{
                get{
                    return this.GetColumn("TenHoaDon");
                }
            }
				
   			public static string TenHoaDonColumn{
			      get{
        			return "TenHoaDon";
      			}
		    }
            
            public IColumn MoTa{
                get{
                    return this.GetColumn("MoTa");
                }
            }
				
   			public static string MoTaColumn{
			      get{
        			return "MoTa";
      			}
		    }
            
            public IColumn CapKH{
                get{
                    return this.GetColumn("CapKH");
                }
            }
				
   			public static string CapKHColumn{
			      get{
        			return "CapKH";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: HoaDon
        /// Primary Key: MaHD
        /// </summary>

        public class HoaDonTable: DatabaseTable {
            
            public HoaDonTable(IDataProvider provider):base("HoaDon",provider){
                ClassName = "HoaDon";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MaHD", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MaKH", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TenHoadon", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("TenNguoiMua", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("NgayMua", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TongTien", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TienNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MaHD{
                get{
                    return this.GetColumn("MaHD");
                }
            }
				
   			public static string MaHDColumn{
			      get{
        			return "MaHD";
      			}
		    }
            
            public IColumn MaKH{
                get{
                    return this.GetColumn("MaKH");
                }
            }
				
   			public static string MaKHColumn{
			      get{
        			return "MaKH";
      			}
		    }
            
            public IColumn TenHoadon{
                get{
                    return this.GetColumn("TenHoadon");
                }
            }
				
   			public static string TenHoadonColumn{
			      get{
        			return "TenHoadon";
      			}
		    }
            
            public IColumn TenNguoiMua{
                get{
                    return this.GetColumn("TenNguoiMua");
                }
            }
				
   			public static string TenNguoiMuaColumn{
			      get{
        			return "TenNguoiMua";
      			}
		    }
            
            public IColumn NgayMua{
                get{
                    return this.GetColumn("NgayMua");
                }
            }
				
   			public static string NgayMuaColumn{
			      get{
        			return "NgayMua";
      			}
		    }
            
            public IColumn TongTien{
                get{
                    return this.GetColumn("TongTien");
                }
            }
				
   			public static string TongTienColumn{
			      get{
        			return "TongTien";
      			}
		    }
            
            public IColumn TienNo{
                get{
                    return this.GetColumn("TienNo");
                }
            }
				
   			public static string TienNoColumn{
			      get{
        			return "TienNo";
      			}
		    }
            
                    
        }
        
}