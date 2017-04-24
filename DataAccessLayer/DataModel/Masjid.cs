namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Masjid")]
    public partial class Masjid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Masjid()
        {
            MasjidConstructionRequests = new HashSet<MasjidConstructionRequest>();
            MasjidExtensionRequests = new HashSet<MasjidExtensionRequest>();
            MasjidLandRequests = new HashSet<MasjidLandRequest>();
            MasjidRenovationRequests = new HashSet<MasjidRenovationRequest>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? HeadUserId { get; set; }

        public int? ZoneId { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        [NotMapped]
        public virtual User User { get; set; }
        public virtual Zone Zone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidConstructionRequest> MasjidConstructionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidExtensionRequest> MasjidExtensionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidLandRequest> MasjidLandRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidRenovationRequest> MasjidRenovationRequests { get; set; }
    }
}
