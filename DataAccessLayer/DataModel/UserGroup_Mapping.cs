using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
   public partial class UserGroup_Mapping
    {
       public UserGroup_Mapping()
       {
           
       }
       public Int64 Id { get; set; }
       public Int64? UserGroupID { get; set; }
       public int? UserID { get; set; }
       public bool IsActive { get; set; }
       [Column(TypeName = "date")]
       public DateTime? CreatedOn { get; set; }

       public virtual User User { get; set; }
       public virtual UserGroup UserGroup { get; set; }
    }
}
