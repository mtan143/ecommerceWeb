using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class HoaDon
    {
        public int MaHD { get; set; }

        [ForeignKey("KhachHang")]
        public int MaKH { get; set; }
        public KhachHang KhachHang { get; set; }
        [ForeignKey("MatHang")]
        public int MaMH { get; set; }
        public MatHang MatHang { get; set; }
        public string Ngay { get; set; }
        public int SoLuong { get; set; }
    }
}