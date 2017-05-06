using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class CourseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? CreatedOn { get; set; }


        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }

    }
}
