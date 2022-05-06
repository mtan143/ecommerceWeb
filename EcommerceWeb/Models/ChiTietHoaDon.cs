using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ChiTietHoaDonID { get; set; }

        public int MatHangID { get; set; }
        [ForeignKey("MatHangID")]
        public MatHang MatHang { get; set; }

        public int HoaDonID { get; set; }
        [ForeignKey("HoaDonID")]
        public HoaDon HoaDon { get; set; }

        public int SoLuong { get; set; }

        public int ThanhTien { get; set; }

    }
}