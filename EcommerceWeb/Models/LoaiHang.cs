using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class LoaiHang
    {
        public LoaiHang() { }
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; }

        public ICollection<MatHang> MatHangs { get; set; }

    }
}