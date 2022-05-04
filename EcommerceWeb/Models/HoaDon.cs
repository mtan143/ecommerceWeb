using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class HoaDon
    {
        public HoaDon()
        {
        }

        [Key]
        public int HoaDonID { get; set; }

        public int KhachHangID { get; set; }
        public KhachHang KhachHang { get; set; }
        public int MatHangID { get; set; }
        public MatHang MatHang { get; set; }
        public string Ngay { get; set; }
        [Range(0, 100, ErrorMessage ="Must greater than 0!")]
        public int SoLuong { get; set; }
    }
}