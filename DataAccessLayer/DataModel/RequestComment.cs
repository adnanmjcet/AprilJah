namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestComment")]
    public partial class RequestComment
    {
        public int Id { get; set; }

        public int? RequestSubmitId { get; set; }

        public int? UserId { get; set; }

        public int? UserTypeId { get; set; }

        [Required]
        [StringLength(150)]
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual User User { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
