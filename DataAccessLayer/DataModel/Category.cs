using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {

        }
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool IsDelete { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
    }
}
