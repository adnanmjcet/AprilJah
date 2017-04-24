namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExistingMadarsaOperationsRequest")]
    public partial class ExistingMadarsaOperationsRequest
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string ShortDescription { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        public int? MadarsaId { get; set; }

        [StringLength(50)]
        public string Girls { get; set; }

        [StringLength(50)]
        public string Boys { get; set; }

        [StringLength(50)]
        public string Teachers { get; set; }

        [StringLength(50)]
        public string IsResidential { get; set; }

        public decimal? MonthlyConst { get; set; }

        [StringLength(100)]
        public string CostPerStudent { get; set; }

        [StringLength(100)]
        public string RevenueSource { get; set; }

        [StringLength(100)]
        public string TotalLandArea { get; set; }

        [StringLength(100)]
        public string ConstructedArea { get; set; }

        [StringLength(100)]
        public string IsRented { get; set; }

        [StringLength(50)]
        public string ChargingStudent { get; set; }

        public int? IfChargingHowmuch { get; set; }

        public byte[] Doc1 { get; set; }

        public byte[] Doc2 { get; set; }

        public byte[] Doc3 { get; set; }

        public byte[] Pic1 { get; set; }

        public byte[] Pic2 { get; set; }

        public byte[] Pic3 { get; set; }

        public int? RequestSubmitId { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? RequestTypeId { get; set; }

        public int? ExpectedStudents { get; set; }

        public virtual Madarsa Madarsa { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual User User { get; set; }
    }
}
