namespace OnlineIs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CALISMASEKLI")]
    public partial class CALISMASEKLI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CALISMASEKLI()
        {
            ILAN = new HashSet<ILAN>();
        }

        [Key]
        public int calismaID { get; set; }

        [StringLength(30)]
        public string calismaADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN> ILAN { get; set; }
    }
}
