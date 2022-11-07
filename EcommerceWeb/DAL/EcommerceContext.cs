using EcommerceWeb.Migrations;
using EcommerceWeb.Models;
using System.Data.Entity;

namespace EcommerceWeb.DAL
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("name=EcommerceConnection") {
                var initializer = new MigrateDatabaseToLatestVersion<EcommerceContext, Configuration>();
                Database.SetInitializer(initializer);
           
        }

        public DbSet<LoaiHang> LoaiHangs { get; set; }
        public DbSet<MatHang> MatHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}