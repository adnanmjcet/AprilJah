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
    public class ExistingMadarsaOperationsRequestBs : IExistingMadarsaOperationsRequest
    {
        private readonly IGenericPattern<ExistingMadarsaOperationsRequest> tbl_ExistingMadarsaOperationsRequestModel;
        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;

        private readonly RequestSubmitModel _RequestSubmitModel;
        public ExistingMadarsaOperationsRequestBs()

        {
            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModel = new RequestSubmitModel();
            tbl_ExistingMadarsaOperationsRequestModel = new GenericPattern<ExistingMadarsaOperationsRequest>();
        }

        public ExistingMadarsaOperationsRequestModel GetById(int id)
        {
            ExistingMadarsaOperationsRequestModel varList = new ExistingMadarsaOperationsRequestModel();
            var item = tbl_ExistingMadarsaOperationsRequestModel.GetById(id);
            item = item ?? new ExistingMadarsaOperationsRequest();
            varList = new ExistingMadarsaOperationsRequestModel
            {
                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
                ExpectedStudents = item.ExpectedStudents,
                Girls = item.Girls,
                Boys = item.Boys,
                Teachers = item.Teachers,
                IsResidential = item.IsResidential,
                MonthlyConst = item.MonthlyConst,
                CostPerStudent = item.CostPerStudent,
                RevenueSource = item.RevenueSource,
                TotalLandArea = item.TotalLandArea,
                ConstructedArea = item.ConstructedArea,
                IsRented = item.IsRented,
                ChargingStudent = item.ChargingStudent,
                IfChargingHowmuch = item.IfChargingHowmuch,

                Doc1 = item.Doc1,
                Doc2 = item.Doc2,
                Doc3 = item.Doc3,
                Pic1 = item.Pic1,
                Pic2 = item.Pic2,
                Pic3 = item.Pic3,
                Status = item.Status,
                CreatedDate = item.CreatedDate,
                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,
                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,
                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,
                RequestSubmitId = item.RequestSubmitId,

            };

            varList.BoardCommentList = new RequestCommentBs().BoardCommentList(id);
            varList.ApprovedList = new RequestApproveRejectBs().ApproveRejectDisplay(id);

            return varList;
        }

        public ExistingMadarsaOperationsRequestModel GetByRequestSubmitId(int id)
        {
            ExistingMadarsaOperationsRequestModel varList = new ExistingMadarsaOperationsRequestModel();
            var item = tbl_ExistingMadarsaOperationsRequestModel.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            item = item ?? new ExistingMadarsaOperationsRequest();
            varList = new ExistingMadarsaOperationsRequestModel
            {

                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
                ExpectedStudents = item.ExpectedStudents,
                Girls = item.Girls,
                Boys = item.Boys,
                Teachers = item.Teachers,
                IfChargingHowmuch = item.IfChargingHowmuch,
                IsResidential = item.IsResidential,
                MonthlyConst = item.MonthlyConst,
                CostPerStudent = item.CostPerStudent,
                RevenueSource = item.RevenueSource,
                TotalLandArea = item.TotalLandArea,
                ConstructedArea = item.ConstructedArea,
                IsRented = item.IsRented,
                ChargingStudent = item.ChargingStudent,
                Doc1 = item.Doc1,
                Doc2 = item.Doc2,
                Doc3 = item.Doc3,
                Pic1 = item.Pic1,
                Pic2 = item.Pic2,
                Pic3 = item.Pic3,
                Status = item.Status,
                CreatedDate = item.CreatedDate,

                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,

                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                RequestSubmitId = item.RequestSubmitId,

            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            varList.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            varList.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            varList.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();

            PanelInvolveBs panelobject = new PanelInvolveBs();
            varList.PannelMemberInvolved = panelobject.InvolveList(id).ToList();
            return varList;
        }
        public ExistingMadarsaOperationsRequestModel GetByRequestSubmitId(int id, int userid)
        {
            ExistingMadarsaOperationsRequestModel varList = new ExistingMadarsaOperationsRequestModel();
            var item = tbl_ExistingMadarsaOperationsRequestModel.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            item = item ?? new ExistingMadarsaOperationsRequest();
            varList = new ExistingMadarsaOperationsRequestModel
            {

                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
                ExpectedStudents = item.ExpectedStudents,
                Girls = item.Girls,
                Boys = item.Boys,
                Teachers = item.Teachers,
                IfChargingHowmuch = item.IfChargingHowmuch,
                IsResidential = item.IsResidential,
                MonthlyConst = item.MonthlyConst,
                CostPerStudent = item.CostPerStudent,
                RevenueSource = item.RevenueSource,
                TotalLandArea = item.TotalLandArea,
                ConstructedArea = item.ConstructedArea,
                IsRented = item.IsRented,
                ChargingStudent = item.ChargingStudent,
                Doc1 = item.Doc1,
                Doc2 = item.Doc2,
                Doc3 = item.Doc3,
                Pic1 = item.Pic1,
                Pic2 = item.Pic2,
                Pic3 = item.Pic3,
                Status = item.Status,
                CreatedDate = item.CreatedDate,


                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,

                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                RequestSubmitId = item.RequestSubmitId,

            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            varList.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            varList.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            varList.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();
            varList.AlreadyExistsInMemberOpinion = varList.ApprovedList == null ? false : varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).Any();
            if (varList.AlreadyExistsInMemberOpinion)
            {
                varList.MemberOpinionId = varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().Id;
                varList.IsAgreed = varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().IsApproved;
                varList.LikeStatus = varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();

            varList.PannelMemberInvolved = panelobject.InvolveList(id).ToList();
            return varList;
        }

        public List<ExistingMadarsaOperationsRequestModel> ExistingMadarsaOperationRequestList()
        {
            List<ExistingMadarsaOperationsRequestModel> _varList = new List<ExistingMadarsaOperationsRequestModel>();
            var varData = tbl_ExistingMadarsaOperationsRequestModel.GetAll().ToList();
            _varList = (from item in varData
                        select new ExistingMadarsaOperationsRequestModel
                        {
                            Id = item.Id,
                            ShortDescription = item.ShortDescription,
                            Location = item.Location,
                            Area = item.Area,
                            ExpectedStudents = item.ExpectedStudents,
                            IfChargingHowmuch = item.IfChargingHowmuch,
                            Girls = item.Girls,
                            Boys = item.Boys,
                            Teachers = item.Teachers,
                            IsResidential = item.IsResidential,
                            MonthlyConst = item.MonthlyConst,
                            CostPerStudent = item.CostPerStudent,
                            RevenueSource = item.RevenueSource,
                            TotalLandArea = item.TotalLandArea,
                            ConstructedArea = item.ConstructedArea,
                            IsRented = item.IsRented,
                            ChargingStudent = item.ChargingStudent,
                            Doc1 = item.Doc1,
                            Doc2 = item.Doc2,
                            Doc3 = item.Doc3,
                            Pic1 = item.Pic1,
                            Pic2 = item.Pic2,
                            Pic3 = item.Pic3,
                            Status = item.Status,
                            CreatedDate = item.CreatedDate,


                            UserId = item.UserId,
                            UserName = (item.User != null) ? item.User.Name : string.Empty,

                            MadarsaId = item.MadarsaId,
                            MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                            RequestTypeId = item.RequestTypeId,
                            RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                            RequestSubmitId = item.RequestSubmitId,

                        }).OrderByDescending(x => x.Id).ToList();
            return _varList;
        }

        public ExistingMadarsaOperationsRequestModel GetDetails(ExistingMadarsaOperationsRequestModel model)
        {
            model = model ?? new ExistingMadarsaOperationsRequestModel();
            if (model.Id != 0)
            {
                model.ExistingMadarsaOperationRequestModelList = ExistingMadarsaOperationRequestList();
                model.UserModelList = UserList();
                model.MadarsaModelList = MadarsaList();
                model.RequestSubmitModelList = RequestSubmitList();
                model.RequestTypeModelList = RequestTypeList();
            }
            model.ExistingMadarsaOperationRequestModelList = ExistingMadarsaOperationRequestList();

            return model;
        }

        public List<MadarsaModel> MadarsaList()
        {
            GenericPattern<Madarsa> _tblList = new GenericPattern<Madarsa>();
            List<MadarsaModel> _ModelList = new List<MadarsaModel>();
            var varData = _tblList.GetAll().ToList();
            _ModelList = (from item in varData
                          select new MadarsaModel
                          {
                              Id = item.Id,
                              Name = item.Name,

                          }).OrderByDescending(x => x.Id).ToList();
            return _ModelList;
        }

        public List<RequestSubmitModel> RequestSubmitList()
        {
            GenericPattern<DataAccessLayer.DataModel.RequestSubmit> _tblList = new GenericPattern<DataAccessLayer.DataModel.RequestSubmit>();
            List<RequestSubmitModel> _ModelList = new List<RequestSubmitModel>();
            var varData = _tblList.GetAll().ToList();
            _ModelList = (from item in varData
                          select new RequestSubmitModel
                          {
                              Id = item.Id,


                          }).OrderByDescending(x => x.Id).ToList();
            return _ModelList;
        }

        public List<RequestTypeModel> RequestTypeList()
        {
            GenericPattern<RequestType> _tblList = new GenericPattern<RequestType>();
            List<RequestTypeModel> _ModelList = new List<RequestTypeModel>();
            var varData = _tblList.GetAll().ToList();
            _ModelList = (from item in varData
                          select new RequestTypeModel
                          {
                              Id = item.Id,
                              Name = item.Name,

                          }).OrderByDescending(x => x.Id).ToList();
            return _ModelList;
        }

        public int Save(ExistingMadarsaOperationsRequestModel model)
        {

            ExistingMadarsaOperationsRequest _tblList = new ExistingMadarsaOperationsRequest(model);

            _RequestSubmitModel.ShortDesc = model.ShortDescription;
            _RequestSubmitModel.UserId = model.UserId;
            _RequestSubmitModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            _RequestSubmitModel.RequestTypeId = model.RequestTypeId;
            RequestSubmit _requestSubmit = new RequestSubmit(_RequestSubmitModel);

            if (_tblList.Id != null && _tblList.Id != 0)
            {
                _tblList.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                tbl_ExistingMadarsaOperationsRequestModel.Update(_tblList);
            }
            else
            {
                _requestSubmit = _RequestSubmit.Insert(_requestSubmit);
                _tblList.RequestSubmitId = _requestSubmit.Id;
                _tblList.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                _tblList = tbl_ExistingMadarsaOperationsRequestModel.Insert(_tblList);
            }


            return _tblList.Id;
        }

        public List<UserModel> UserList()
        {
            GenericPattern<User> _tblList = new GenericPattern<User>();
            List<UserModel> _ModelList = new List<UserModel>();
            var varData = _tblList.GetAll().ToList();
            _ModelList = (from item in varData
                          select new UserModel
                          {
                              Id = item.Id,
                              Name = item.Name,

                          }).OrderByDescending(x => x.Id).ToList();
            return _ModelList;
        }
    }
}
