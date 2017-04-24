using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
   public class RequestTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public List<RequestTypeModel> RequestTypeLists { get; set; }
    }
}
