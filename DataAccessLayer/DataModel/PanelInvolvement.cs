namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PanelInvolvement")]
    public partial class PanelInvolvement
    {
        public int Id { get; set; }

        public int? UserTypeId { get; set; }

        public int? UserId { get; set; }

        public bool? IsObject { get; set; }

        public int? RequestSubmitId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual User User { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
