using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DataModel
{
    [Table("Course_Test")]
    public partial class Course_Test
    {

        public Course_Test()
        {

        }
        public long Id { get; set; }
        public long CourseID { get; set; }

        [StringLength(550)]
        public string Question { get; set; }


        [StringLength(250)]
        public string Answer1 { get; set; }

        [StringLength(250)]
        public string Answer2 { get; set; }
        [StringLength(250)]
        public string Answer3 { get; set; }

        [StringLength(250)]
        public string Answer4 { get; set; }
        [StringLength(250)]
        public string CorrectAnswer { get; set; }

        [StringLength(50)]
        public string Mark { get; set; }
        [StringLength(650)]
        public string Reason { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }

        
        public long CreatedBy { get; set; }

        
    }
}
