using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
  public  interface IRequestLikeDisLike
    {
        List<RequestLikeModel> RequestApproveList();

        RequestApproveModel GetDetails(RequestLikeModel model);

        int Save(RequestLikeModel model);

        RequestLikeModel GetById(int id);
    }
}
