    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class KhachHang
    {
        static KhachHang instance;

        private static object locker = new object();
        public static KhachHang GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new KhachHang();
                    }
                }
            }
            return instance;
        }

        public KhachHang()
        {
        }

        public KhachHang(string tenKH, string diaChi, string dienThoai, string username, string password) : this(tenKH, diaChi)
        {
            DienThoai = dienThoai;
            Username = username;
            Password = password;
        }

        public KhachHang(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Key]
        public int KhachHangID { get; set; }

        public string TenKH { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        [Required(ErrorMessage ="Username Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<DanhGia> DanhGias{ get; set; }
    }
}