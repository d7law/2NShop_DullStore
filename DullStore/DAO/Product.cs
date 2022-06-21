namespace DullStore.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IDProduct { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }

        public int? UnitPrice { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductDate { get; set; }

        [StringLength(50)]
        public string Available { get; set; }

        public int? IDCategory { get; set; }

        [StringLength(50)]
        public string Descriptions { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
