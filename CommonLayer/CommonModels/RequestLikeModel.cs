using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
  public  class RequestLikeModel
    {
        public int Id { get; set; }

        public int RequestSubmitId { get; set; }

        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public bool IsLike { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        public List<RequestSubmitModel> RequestSubmit { get; set; }

        public List<UserModel> User { get; set; }

        public List<UserTypeModel> UserType { get; set; }
    }
}
