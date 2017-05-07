using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
    [Table("UserGroup")]
    public partial class UserGroup
    {

        public UserGroup()
        {
            this.UserGroup_Mapping = new List<UserGroup_Mapping>();
        }
        public Int64 Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<UserGroup_Mapping> UserGroup_Mapping { get; set; }
    }
}
