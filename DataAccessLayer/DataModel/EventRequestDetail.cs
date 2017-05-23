namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventRequestDetail
    {
        public int Id { get; set; }

        public int? EventRequestId { get; set; }

        [StringLength(50)]
        public string SpeakerName { get; set; }

        [StringLength(150)]
        public string Topic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public string Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
    }
}
