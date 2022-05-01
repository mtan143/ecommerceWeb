﻿using EcommerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceWeb.DAL
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("name=DefaultConnection") { }

        public DbSet<LoaiHang> LoaiHangs { get; set; }
        public DbSet<MatHang> MatHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}