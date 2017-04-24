namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasjidLandRequest")]
    public partial class MasjidLandRequest
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string ShortDescription { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        public int? MasjidId { get; set; }

        [StringLength(50)]
        public string TimePeriod { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? AmountNeeded { get; set; }

        [StringLength(50)]
        public string LandArea { get; set; }

        public decimal? LandPrice { get; set; }

        [StringLength(50)]
        public string PurchasingFrom { get; set; }

       
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

        public virtual Masjid Masjid { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual User User { get; set; }
    }
}
