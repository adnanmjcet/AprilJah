using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? CreatedDate { get; set; }
        public bool IsChecked { get; set; }
    }
}
