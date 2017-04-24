namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MadarsaExtensionRequest")]
    public partial class MadarsaExtensionRequest
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
        public string ConstructionCost { get; set; }

        [StringLength(50)]
        public string ExistingFloors { get; set; }

        public decimal? AmountNeeded { get; set; }

        [StringLength(50)]
        public string Engineer { get; set; }
        public byte[] Elevation { get; set; }


        public byte[] Paln { get; set; }


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

        public virtual Madarsa Madarsa { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual User User { get; set; }
    }
}
