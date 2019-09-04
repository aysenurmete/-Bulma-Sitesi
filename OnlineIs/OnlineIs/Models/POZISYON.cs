namespace OnlineIs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POZISYON")]
    public partial class POZISYON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POZISYON()
        {
            ILAN = new HashSet<ILAN>();
        }

        public int pozisyonID { get; set; }

        [StringLength(100)]
        public string pozisyonADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN> ILAN { get; set; }
    }
}
