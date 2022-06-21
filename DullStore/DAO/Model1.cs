using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DullStore.DAO
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User1> Users1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IDCategory);

            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.dongia)
                .IsFixedLength();

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.tendanhmuc)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMuc)
                .HasForeignKey(e => e.madanhmuc);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.SanPhams1)
                .WithOptional(e => e.DanhMuc1)
                .HasForeignKey(e => e.madanhmuc);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.GioHang)
                .HasForeignKey(e => e.magiohang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHangs1)
                .WithRequired(e => e.GioHang1)
                .HasForeignKey(e => e.magiohang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.makhachhang);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHangs1)
                .WithOptional(e => e.KhachHang1)
                .HasForeignKey(e => e.makhachhang);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.magiay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHangs1)
                .WithRequired(e => e.SanPham1)
                .HasForeignKey(e => e.magiay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Style>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.Style)
                .HasForeignKey(e => e.mastyle);

            modelBuilder.Entity<Style>()
                .HasMany(e => e.SanPhams1)
                .WithOptional(e => e.Style1)
                .HasForeignKey(e => e.mastyle);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
