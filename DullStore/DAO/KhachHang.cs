namespace DullStore.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
            GioHangs1 = new HashSet<GioHang>();
        }

        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string hoten { get; set; }

        [Required]
        [StringLength(100)]
        public string diachi { get; set; }

        [Required]
        [StringLength(50)]
        public string sodienthoai { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs1 { get; set; }
    }
}
