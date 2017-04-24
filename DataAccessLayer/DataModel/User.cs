namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            EventRequests = new HashSet<EventRequest>();
            ExistingMadarsaOperationsRequests = new HashSet<ExistingMadarsaOperationsRequest>();
            Madarsas = new HashSet<Madarsa>();
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
            RequestSubmits = new HashSet<RequestSubmit>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? RoleId { get; set; }

        public int? UserTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventRequest> EventRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExistingMadarsaOperationsRequest> ExistingMadarsaOperationsRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Madarsa> Madarsas { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestSubmit> RequestSubmits { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
