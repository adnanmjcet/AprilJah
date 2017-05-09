namespace DataAccessLayer.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Volunteer")]
    public partial class Volunteer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Occupation { get; set; }

        public int? ZoneId { get; set; }

        [StringLength(200)]
        public string Skills { get; set; }

        [StringLength(200)]
        public string VolunteerFor { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
