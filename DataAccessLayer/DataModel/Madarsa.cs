namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Madarsa")]
    public partial class Madarsa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Madarsa()
        {
            ExistingMadarsaOperationsRequests = new HashSet<ExistingMadarsaOperationsRequest>();
            MadarsaExtensionRequests = new HashSet<MadarsaExtensionRequest>();
            MadarsaLandRequests = new HashSet<MadarsaLandRequest>();
            NewMadarsaOperationsRequests = new HashSet<NewMadarsaOperationsRequest>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? HeadUserId { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        public int? ZoneId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExistingMadarsaOperationsRequest> ExistingMadarsaOperationsRequests { get; set; }

        public virtual User User { get; set; }

        public virtual Zone Zone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MadarsaExtensionRequest> MadarsaExtensionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MadarsaLandRequest> MadarsaLandRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewMadarsaOperationsRequest> NewMadarsaOperationsRequests { get; set; }
    }
}
