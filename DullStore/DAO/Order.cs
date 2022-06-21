namespace DullStore.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int IDOrder { get; set; }

        [StringLength(50)]
        public string NameUser { get; set; }

        [StringLength(50)]
        public string Addresss { get; set; }

        public int? SDT { get; set; }

        public int? UnitPriceSale { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }

        public int? IDProduct { get; set; }

        public virtual Product Product { get; set; }
    }
}
