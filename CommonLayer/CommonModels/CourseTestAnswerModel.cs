using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class CourseTestAnswerModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public long CourseID { get; set; }

        public int Score { get; set; }
        public long CourseTestID { get; set; }

        public string Answer { get; set; }

        public int UserID { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime? CreatedOn { get; set; }
        
    }
}
