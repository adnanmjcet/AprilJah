using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class CourseTestModel
    {

        public long Id { get; set; }

        public long CourseID { get; set; }

        


        public string Question { get; set; }

        public string Answer1 { get; set; }


        public string Answer2 { get; set; }

        public string Answer3 { get; set; }


        public string Answer4 { get; set; }

        public string CorrectAnswer { get; set; }


        public string Mark { get; set; }

        public string Reason { get; set; }


        public DateTime? CreatedOn { get; set; }


        public long CreatedBy { get; set; }
    }
}
