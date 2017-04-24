using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLayer.Implementation
{
    public class RequestLikeDisLikeBs : IRequestLikeDisLike
    {
        private readonly IGenericPattern<RequestLike> _RequestLike;
        private readonly RequestLikeModel _RequestLikeModel;
        public RequestLikeDisLikeBs()
        {
            _RequestLike = new GenericPattern<RequestLike>();
            _RequestLikeModel = new RequestLikeModel();
        }

        public RequestLikeModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestApproveModel GetDetails(RequestLikeModel model)
        {
            throw new NotImplementedException();
        }

        public List<RequestLikeModel> RequestApproveList()
        {
            throw new NotImplementedException();
        }

        public int Save(RequestLikeModel model)
        {
            RequestLike _requestLike = new RequestLike(model);
            if (model.Id != null && model.Id != 0)
            {
                _RequestLike.Update(_requestLike);

            }
            else
            {
                //  _requestApprove.CreatedDate = System.DateTime.Now;

                _requestLike = _RequestLike.Insert(_requestLike);
            }

            return _requestLike.Id;
        }
    }
}
