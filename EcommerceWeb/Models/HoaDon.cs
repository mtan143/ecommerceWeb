using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWeb.Models
{
    public class HoaDon
    {
        static HoaDon instance;

        private static object locker = new object();
        public static HoaDon GetCart()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new HoaDon();
                    }
                }
            }
            return instance;
        }

            public HoaDon() { }

        [Key]
        public int HoaDonID { get; set; }

        public int KhachHangID { get; set; }
        [ForeignKey("KhachHangID")]
        public KhachHang KhachHang { get; set; }

        public DateTime Ngay { get; set; }

        public int TongTien { get; set; }

        //0 đã đặt
        //1 đang xử lý
        //2 đang giao hàng
        //3 giao thành công
        //4 đang gửi yêu cầu huỷ
        //5 đã huỷ
        //6 huỷ không thành công
        public int TrangThai { get; set; }

        public virtual ICollection<ChiTietHoaDon> MatHangs { get; set; }
    }
}