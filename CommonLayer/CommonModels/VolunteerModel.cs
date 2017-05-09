using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
  public  class VolunteerModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
         
        public string Email { get; set; }

        public string Contact { get; set; }

        public string Occupation { get; set; }

        public int? ZoneId { get; set; }

        public string Skills { get; set; }

        public string VolunteerFor { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<VolunteerModel> VolunteerList { get; set; }
    }
}
