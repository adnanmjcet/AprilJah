using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class EventRequestDetailModel
    {
        public int Id { get; set; }

        public int? EventRequestId { get; set; }

        public string EventRequestName { get; set; }

        public string SpeakerName { get; set; }

        public DateTime? Date { get; set; }

        public string Topic { get; set; }

        public string Time { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<EventRequestModel> EventRequestModelList { get; set; }

        public List<EventRequestDetailModel> EventRequestDetailModelList { get; set; }


    }
}
