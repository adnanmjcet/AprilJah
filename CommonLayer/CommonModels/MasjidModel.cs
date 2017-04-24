using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class MasjidModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int? HeadUserId { get;  set; }
        public string UserName { get; set; }

        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string Mobile { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public List<UserModel> UserLists { get; set; }

        public List<ZoneModel> ZoneLists { get; set; }
        public List<MasjidModel> MasjidLists { get; set; }


    }
}
