using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EcommerceWeb.Models
{
    public class DanhGia
    {
        static DanhGia instance;

        private static object locker = new object();
        public static DanhGia GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new DanhGia();
                    }
                }
            }
            return instance;
        }

        public DanhGia(){}

        [Key]
        public int DanhGiaID { get; set; }

        public string NoiDung { get; set; }

        public int Sao { get; set; }

        public DateTime ThoiGian { get; set; }

        public DateTime LanCuoiChinhSua { get; set; }

        public int KhachHangID { get; set; }
        [ForeignKey("KhachHangID")]
        public virtual KhachHang KhachHang { get; set; }

        public int MatHangID { get; set; }
        [ForeignKey("MatHangID")]
        public virtual MatHang MatHang { get; set; }
    }
}