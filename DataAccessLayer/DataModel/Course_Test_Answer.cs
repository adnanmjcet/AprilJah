using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.DataModel
{
    [Table("Course_Test_Answer")]
    public partial class Course_Test_Answer
    {
        public Course_Test_Answer()
        {

        }
        public long Id { get; set; }
        public long CourseID { get; set; }


        public long CourseTestID { get; set; }
        [StringLength(250)]
        public string Answer { get; set; }

        public int UserID { get; set; }

        public bool IsCorrect { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }

        public virtual User User { get; set; }

    }
}
