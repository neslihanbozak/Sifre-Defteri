namespace SifreDefteri.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Veri = new HashSet<Veri>();
        }

        public int kullaniciID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public string eposta { get; set; }

        [StringLength(10)]
        public string sifre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veri> Veri { get; set; }
    }
}
