﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceWeb.Models
{
    public class ChiNhanh
    {
        public ChiNhanh() { }

        [Key]
        public int ChiNhanhID { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string TenCN { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string DiaChi { get; set; }

        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}