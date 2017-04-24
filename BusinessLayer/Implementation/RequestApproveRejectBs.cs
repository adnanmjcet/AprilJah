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
    public class RequestApproveRejectBs : RequestApproveReject
    {
        private readonly IGenericPattern<RequestApprove> _RequestApprove;
        private readonly RequestApproveModel _RequestApproveModel;
        public RequestApproveRejectBs()
        {
            _RequestApprove = new GenericPattern<RequestApprove>();
            _RequestApproveModel = new RequestApproveModel();
        }

        public RequestApproveModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestApproveModel GetDetails(RequestApproveModel model)
        {
            throw new NotImplementedException();
        }

        public List<RequestApproveModel> RequestApprovedList()
        {
            List<RequestApproveModel> _RequestList = new List<RequestApproveModel>();
            var requestList = _RequestApprove.GetAll().ToList();
            _RequestList = (from item in requestList
                            select new RequestApproveModel
                            {
                                Id = item.Id,
                                IsApproved = Convert.ToBoolean(item.IsApproved),
                                ShortDesc = item.RequestSubmit.ShortDesc,
                                RequestSubmitId = Convert.ToInt32(item.RequestSubmitId),
                                UserName = item.User.Name,
                                UserTypeName = item.UserType.Name,
                                UserTypeId = Convert.ToInt32(item.UserTypeId),
                                //Status=item.Status,

                            }).Where(x => x.IsApproved == true && x.UserTypeId == 2).ToList();
            return _RequestList;
        }

        public List<RequestApproveModel> RequestRejectedList()
        {
            List<RequestApproveModel> _RequestList = new List<RequestApproveModel>();
            var requestList = _RequestApprove.GetAll().ToList();
            _RequestList = (from item in requestList
                            select new RequestApproveModel
                            {
                                Id = item.Id,
                                IsApproved = Convert.ToBoolean(item.IsApproved),
                                ShortDesc = item.RequestSubmit.ShortDesc,
                                RequestSubmitId = Convert.ToInt32(item.RequestSubmitId),
                                UserName = item.User.Name,
                                UserTypeName = item.UserType.Name,
                                UserTypeId = Convert.ToInt32(item.UserTypeId),
                                //Status=item.Status,

                            }).Where(x => x.IsApproved == false && x.UserTypeId == 2).ToList();
            return _RequestList;
        }

        public int Save(RequestApproveModel model)
        {

            RequestApprove _requestApprove = new RequestApprove(model);
            if (model.Id != null && model.Id != 0)
            {
                _RequestApprove.Update(_requestApprove);

            }
            else
            {
                //  _requestApprove.CreatedDate = System.DateTime.Now;

                _requestApprove = _RequestApprove.Insert(_requestApprove);
            }

            return _requestApprove.Id;
        }

        public List<RequestApproveModel> ApproveRejectDisplay(int id)
        {
            List<RequestApproveModel> _RequestList = new List<RequestApproveModel>();
            var requestList = _RequestApprove.GetAll().Where(x => x.RequestSubmitId == id).ToList();
            _RequestList = (from item in requestList
                            select new RequestApproveModel
                            {
                                Id = item.Id,
                                IsApproved = Convert.ToBoolean(item.IsApproved),
                                ShortDesc = item.RequestSubmit.ShortDesc,
                                RequestSubmitId = Convert.ToInt32(item.RequestSubmitId),
                                UserName = item.User.Name,
                                UserTypeName = item.UserType.Name,
                                UserTypeId = Convert.ToInt32(item.UserTypeId),
                                UserId=(Int32)item.UserId,
                                LikeStatus=item.IsLiked


                            }).ToList();
            return _RequestList;
        }
    }
}
