using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DataModel
{
    [Table("CourseSession")]
    public partial class CourseSession
    {
        public CourseSession()
        {

        }

        public long Id { get; set; }
        public long CourseID { get; set; }
        [StringLength(50)]
        public string Topic { get; set; }
        [StringLength(50)]
        public string Document1 { get; set; }
        [StringLength(50)]
        public string Document2 { get; set; }
        [StringLength(50)]
        public string AudioLink { get; set; }
        [StringLength(50)]
        public string VideoLink { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        
        public long CreatedBy { get; set; }
    }
}
