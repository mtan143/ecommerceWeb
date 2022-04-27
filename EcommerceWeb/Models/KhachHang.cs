using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}