using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EcommerceWeb.Models
{
    public class MatHang
    {
        static MatHang instance;

        private static object locker = new object();
        public static MatHang GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new MatHang();
                    }
                }
            }
            return instance;
        }

        public MatHang(){}

        [Key]
        public int MatHangID { get; set; }

        [StringLength(1000, MinimumLength =10)]
        public string TenMH { get; set; }

        [Range(10000, 1000000, ErrorMessage ="Price must in [10.000 - 1.000.000]")]
        public int DonGia { get; set; }

        public string MoTa { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }
        public int SoLuong { get; set; }

        //0: Female, 1: Male
        public byte? Gender { get; set; }

        public int LoaiID { get; set; }
        [ForeignKey("LoaiID")]
        public LoaiHang LoaiHang{ get; set; }

        //[Required(ErrorMessage = "Image Required!")]
        public string HinhAnh { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
        public int TongSoLuong { get; set; }
        public int SoLuongTonKho { get; set; }
        public virtual ICollection<ChiTietHoaDon> HoaDons { get; set; }
        public virtual ICollection<ChiNhanh> ChiNhanhs { get; set; }
        public virtual ICollection<DanhGia> DanhGias{ get; set; }
    }
}