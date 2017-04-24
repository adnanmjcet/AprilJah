using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class RequestSubmitBs:IRequestSubmit
    {

        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;
        private readonly RequestSubmitModel _RequestSubmitModelqamodel;
        public RequestSubmitBs()
        {
            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModelqamodel = new RequestSubmitModel();
        }


        public List<RequestSubmitModel> RequestSubmitList()
        {
            List<RequestSubmitModel> _RequestList = new List<RequestSubmitModel>();
            var requestList = _RequestSubmit.GetAll().ToList();
            _RequestList = (from item in requestList
                            select new RequestSubmitModel
                            {
                                Id = item.Id,
                                RequestTypeName = item.RequestType.Name,
                                RequestTypeId=item.RequestTypeId,
                                UserName = item.User.UserName,
                                ShortDesc = item.ShortDesc,
                                IsApproved = item.IsApproved,
                                Status = item.Status,
                                UserId=item.UserId
                            }).OrderByDescending(x => x.Id).ToList();
            return _RequestList;
        }

        public List<RequestSubmitModel> AmeerApprovedList()
        {
            List<RequestSubmitModel> _RequestList = new List<RequestSubmitModel>();
            var requestList = _RequestSubmit.GetAll().Where(x => x.IsApproved == true).ToList();
            _RequestList = (from item in requestList
                            select new RequestSubmitModel
                            {
                                Id = item.Id,
                                RequestTypeName = item.RequestType.Name,
                                RequestTypeId = item.RequestTypeId,
                                UserName = item.User.Name,
                                ShortDesc = item.ShortDesc,
                                IsApproved = item.IsApproved,
                                Status = item.Status
                            }).OrderByDescending(x => x.Id).ToList();

            return _RequestList;
        }

        public List<RequestSubmitModel> AmeerRejectedList()
        {
            List<RequestSubmitModel> _RequestList = new List<RequestSubmitModel>();
            var requestList = _RequestSubmit.GetAll().Where(x => x.IsApproved == false).ToList();
            _RequestList = (from item in requestList
                            select new RequestSubmitModel
                            {
                                Id = item.Id,
                                RequestTypeName = item.RequestType.Name,
                                RequestTypeId = item.RequestTypeId,
                                UserName = item.User.Name,
                                ShortDesc = item.ShortDesc,
                                IsApproved = item.IsApproved,
                                Status = item.Status
                            }).OrderByDescending(x => x.Id).ToList();

            return _RequestList;
        }

        public int Save(RequestSubmitModel model)
        {
            RequestSubmit requestSubmit = new RequestSubmit(model);
            int id = model.Id;
            var res = _RequestSubmit.GetById(id);
            res.IsApproved = model.IsApproved;
            res.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            if (model.Id != null && model.Id != 0)
            {
                _RequestSubmit.Update(res);

            }
            else
            {

                requestSubmit = _RequestSubmit.Insert(requestSubmit);
            }

            return requestSubmit.Id;
        }

        //public RequestSubmitModel GetDetails(RequestSubmitModel model)
        //{
        //    model = model ?? new HalqaModel();
        //    if (model.Id != 0)
        //    {
        //        model.HalqaLists = HalqaList();

        //    }
        //    model.HalqaLists = HalqaList();

        //    return model;

        //}


        //public int Save(RequestSubmitModel model)
        //{
        //    RequestSubmit _RequestSubmit = new RequestSubmit(model);
        //    if (model.Id != null && model.Id != 0)
        //    {
        //        _tbl_Halqa.Update(_tbl_halqa);

        //    }
        //    else
        //    {
        //        _tbl_halqa.CreatedDate = System.DateTime.Now;
        //        _tbl_halqa = _tbl_Halqa.Insert(_tbl_halqa);
        //    }

        //    return _tbl_halqa.Id;
        //}

        //public MasjidConstructionRequestModel GetById(int id)
        //{
        //    RequestSubmitModel requestModel = new RequestSubmitModel();
        //    var RequestId = _RequestSubmit.GetById(id);
        //    RequestId = RequestId ?? new RequestSubmit();
        //    requestModel = new MasjidConstructionRequestModel
        //    {
        //        Id = RequestId.Id,
        //        RequestTypeName = RequestId.RequestType.Name,
        //        UserName = RequestId.User.UserName,
        //        ShortDesc = RequestId.ShortDesc,
        //        IsApproved = RequestId.IsApproved,
        //        Status = RequestId.Status
        //    };
        //    return requestModel;
        //}
    }
}
