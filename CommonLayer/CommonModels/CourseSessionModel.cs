using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class CourseSessionModel
    {
        public long Id { get; set; }
        public long CourseID { get; set; }
        public string Topic { get; set; }

        public string Document1 { get; set; }

        public string Document2 { get; set; }

        public string AudioLink { get; set; }
        public string VideoLink { get; set; }

        public DateTime? CreatedOn { get; set; }


        
        public long CreatedBy { get; set; }

        


    }
}
