﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class KhachHang
    {
        public KhachHang()
        {
        }

        public KhachHang(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        [Required(ErrorMessage ="Username Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}