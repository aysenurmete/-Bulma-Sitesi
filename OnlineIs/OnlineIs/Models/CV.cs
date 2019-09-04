namespace OnlineIs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CV")]
    public partial class CV
    {
        public int cvID { get; set; }

        public int? egitimseviyeID { get; set; }

        [StringLength(5)]
        public string cinsiyet { get; set; }

        public int? yabancidilID { get; set; }

        [StringLength(200)]
        public string yetenek { get; set; }

        [StringLength(50)]
        public string referans { get; set; }

        public int okulID { get; set; }

        public DateTime? dogumgunu { get; set; }

        public Guid? UserId { get; set; }

        [Column(TypeName = "image")]
        public byte[] fotograf { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        public virtual EGITIMSEVIYESI EGITIMSEVIYESI { get; set; }

        public virtual OKUL OKUL { get; set; }

        public virtual YABANCIDIL YABANCIDIL { get; set; }
    }
}
