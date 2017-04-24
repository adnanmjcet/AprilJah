namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventRequest")]
    public partial class EventRequest
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string EventName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string TotalSpeakers { get; set; }

        public int? EventType { get; set; }

        [StringLength(50)]
        public string Venu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? UserId { get; set; }

        public int? RequestSubmitId { get; set; }

        public int? RequestTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual EventMaster EventMaster { get; set; }

        public virtual RequestSubmit RequestSubmit { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual User User { get; set; }
    }
}
