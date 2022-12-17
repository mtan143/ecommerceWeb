using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class LoaiHang
    {
        static LoaiHang instance;

        private static object locker = new object();
        public static LoaiHang GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoaiHang();
                    }
                }
            }
            return instance;
        }

        public LoaiHang() { }
        [Key]
        public int LoaiID { get; set; }

        public string TenLoai { get; set; }

        public ICollection<MatHang> MatHangs { get; set; }

    }
}