using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DataModel
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {

        }
        public long Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(50)]
        public string Description { get; set; }

        public bool Status { get; set; }

        public bool IsDelete { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }

    }
}
