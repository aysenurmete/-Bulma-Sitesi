namespace OnlineIs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILAN")]
    public partial class ILAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILAN()
        {
            aspnet_Users1 = new HashSet<aspnet_Users>();
        }

        public int ilanID { get; set; }

        [StringLength(60)]
        public string ilanADI { get; set; }

        public int? pozisyonID { get; set; }

        public int? departmanID { get; set; }

        public int? calismaID { get; set; }

        public int? yabancidilID { get; set; }

        public int? egitimseviyeID { get; set; }

        public int? sehirID { get; set; }

        public int? sektorID { get; set; }

        [StringLength(200)]
        public string nitelikler { get; set; }

        public Guid? UserId { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual CALISMASEKLI CALISMASEKLI { get; set; }

        public virtual DEPARTMAN DEPARTMAN { get; set; }

        public virtual EGITIMSEVIYESI EGITIMSEVIYESI { get; set; }

        public virtual POZISYON POZISYON { get; set; }

        public virtual SEHIR SEHIR { get; set; }

        public virtual SEKTOR SEKTOR { get; set; }

        public virtual YABANCIDIL YABANCIDIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Users> aspnet_Users1 { get; set; }
    }
}
