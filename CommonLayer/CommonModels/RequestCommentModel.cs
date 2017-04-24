using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class RequestCommentModel
    {

        public int Id { get; set; }

        public int RequestSubmitId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }


        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }


        public string Comment { get; set; }


        public DateTime CreatedDate { get; set; }

        public List<RequestSubmitModel> RequestSubmit { get; set; }

        public List<UserModel> User { get; set; }

        public List<UserTypeModel> UserType { get; set; }

        public List<RequestCommentModel> RequestCommentList { get; set; }

    }
}
