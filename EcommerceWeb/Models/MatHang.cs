using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class MatHang
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int DonGia { get; set; }
        public string MoTa { get; set; }
        [ForeignKey("LoaiHang")]
        public int MaLoai { get; set; }
        public LoaiHang LoaiHang{ get; set; }
        public string HinhAnh { get; set; }
    }
}