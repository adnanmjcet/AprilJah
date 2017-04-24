using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CommonLayer.CommonModels
{
    public class RequestApproveModel
    {
        public int Id { get; set; }

        public int RequestSubmitId { get; set; }

        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public string UserName { get; set; }

        public string ShortDesc { get; set; }

        public string UserTypeName { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<RequestSubmitModel> RequestSubmit { get; set; }

        public List<UserModel> User { get; set; }

        public List<UserTypeModel> UserType { get; set; }


        public List<RequestApproveModel> ApprovedList { get; set; }

        public List<RequestApproveModel> RejectedList { get; set; }
        public bool? LikeStatus { get; set; }
    }
}
