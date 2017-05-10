using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class PostNotificationModel
    {
        public PostNotificationModel()
        {
            UserGroupList = new List<Int64>();
        }
        public int UserType { get; set; }
        public int CategoryID { get; set; }
        public bool IsSms { get; set; }
        public bool IsMobileNotification { get; set; }
        public List<Int64> UserGroupList  { get; set; }
        public string Message { get; set; }
    }
}
