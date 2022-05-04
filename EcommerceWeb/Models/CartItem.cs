using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }
        public string MatHangID { get; set; }
        public MatHang MatHang { get; set; }
        public int Quantity { get; set; }
    }
}