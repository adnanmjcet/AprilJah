using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class EventMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EventMasterModel> EventMasterModelList { get; set; }

    }
}
