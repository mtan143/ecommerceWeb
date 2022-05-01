using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class MatHang
    {
        public MatHang()
        {
        }

        public int Id { get; set; }
        [StringLength(1000, MinimumLength =10)]
        public string TenMH { get; set; }
        [Range(10000, 1000000, ErrorMessage ="Price must in [10.000 - 1.000.000]")]
        public int DonGia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
        public LoaiHang LoaiHang{ get; set; }
        [Required(ErrorMessage = "Image Required!")]
        public string HinhAnh { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}