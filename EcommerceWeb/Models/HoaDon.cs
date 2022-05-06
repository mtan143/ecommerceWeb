using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWeb.Models
{
    public class HoaDon
    {
        public HoaDon() { }

        [Key]
        public int HoaDonID { get; set; }

        public int KhachHangID { get; set; }
        [ForeignKey("KhachHangID")]
        public KhachHang KhachHang { get; set; }

        public DateTime Ngay { get; set; }

        public int TongTien { get; set; }

        public virtual ICollection<ChiTietHoaDon> MatHangs { get; set; }
    }
}