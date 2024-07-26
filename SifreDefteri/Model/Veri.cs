namespace SifreDefteri.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Veri")]
    public partial class Veri
    {
        public int veriID { get; set; }

        public int? KullaniciID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? tarih { get; set; }

        [StringLength(50)]
        public string eposta { get; set; }

        [StringLength(20)]
        public string sifre { get; set; }

        [StringLength(50)]
        public string aciklama { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
