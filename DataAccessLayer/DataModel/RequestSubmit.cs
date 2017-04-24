namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestSubmit")]
    public partial class RequestSubmit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestSubmit()
        {
            EventRequests = new HashSet<EventRequest>();
            ExistingMadarsaOperationsRequests = new HashSet<ExistingMadarsaOperationsRequest>();
            MadarsaExtensionRequests = new HashSet<MadarsaExtensionRequest>();
            MadarsaLandRequests = new HashSet<MadarsaLandRequest>();
            MasjidConstructionRequests = new HashSet<MasjidConstructionRequest>();
            MasjidExtensionRequests = new HashSet<MasjidExtensionRequest>();
            MasjidLandRequests = new HashSet<MasjidLandRequest>();
            MasjidRenovationRequests = new HashSet<MasjidRenovationRequest>();
            NewMadarsaOperationsRequests = new HashSet<NewMadarsaOperationsRequest>();
            PanelInvolvements = new HashSet<PanelInvolvement>();
            RequestApproves = new HashSet<RequestApprove>();
            RequestComments = new HashSet<RequestComment>();
            RequestLikes = new HashSet<RequestLike>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string ShortDesc { get; set; }

        public int? RequestTypeId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? UserId { get; set; }

        public bool? IsApproved { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

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
        public virtual ICollection<PanelInvolvement> PanelInvolvements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestApprove> RequestApproves { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestComment> RequestComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestLike> RequestLikes { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual User User { get; set; }
    }
}
