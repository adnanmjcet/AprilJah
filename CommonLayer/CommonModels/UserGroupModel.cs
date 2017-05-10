using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
   public class UserGroupModel
    {
       public UserGroupModel()
       {
           UserList = new List<UserGroupModel>();
       }
        public Int64 Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public int? UserID { get; set; }
        public Int64? UserGroupID { get; set; }
        public string Name { get; set; }

        public List<int> UserCheckList { get; set; }
        public string UserTypeName { get; set; }
        public bool IsActive { get; set; }
        public int UserCount { get; set; }
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public bool IsSelected { get; set; }

        public List<UserGroupModel> UserList { get; set; }

    }
}
