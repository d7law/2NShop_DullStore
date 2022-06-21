namespace DullStore.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
            ChiTietGioHangs1 = new HashSet<ChiTietGioHang>();
        }

        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string ten { get; set; }

        public decimal giaban { get; set; }

        [StringLength(200)]
        public string linkanh { get; set; }

        [Required]
        [StringLength(50)]
        public string xuatxu { get; set; }

        public int? madanhmuc { get; set; }

        public int? mastyle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs1 { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual DanhMuc DanhMuc1 { get; set; }

        public virtual Style Style { get; set; }

        public virtual Style Style1 { get; set; }
    }
}
