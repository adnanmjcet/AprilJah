using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
   public class UserGroupModel
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public int? UserID { get; set; }
        public int? UserGroupID { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
     
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
