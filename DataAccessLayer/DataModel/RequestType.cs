namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestType")]
    public partial class RequestType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestType()
        {
            DefaultInovlvements = new HashSet<DefaultInovlvement>();
            EventRequests = new HashSet<EventRequest>();
            ExistingMadarsaOperationsRequests = new HashSet<ExistingMadarsaOperationsRequest>();
            MadarsaExtensionRequests = new HashSet<MadarsaExtensionRequest>();
            MadarsaLandRequests = new HashSet<MadarsaLandRequest>();
            MasjidConstructionRequests = new HashSet<MasjidConstructionRequest>();
            MasjidExtensionRequests = new HashSet<MasjidExtensionRequest>();
            MasjidLandRequests = new HashSet<MasjidLandRequest>();
            MasjidRenovationRequests = new HashSet<MasjidRenovationRequest>();
            NewMadarsaOperationsRequests = new HashSet<NewMadarsaOperationsRequest>();
            RequestSubmits = new HashSet<RequestSubmit>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DefaultInovlvement> DefaultInovlvements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventRequest> EventRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExistingMadarsaOperationsRequest> ExistingMadarsaOperationsRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MadarsaExtensionRequest> MadarsaExtensionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MadarsaLandRequest> MadarsaLandRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidConstructionRequest> MasjidConstructionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidExtensionRequest> MasjidExtensionRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidLandRequest> MasjidLandRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasjidRenovationRequest> MasjidRenovationRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewMadarsaOperationsRequest> NewMadarsaOperationsRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestSubmit> RequestSubmits { get; set; }
    }
}
