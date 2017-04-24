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
    public class MasjidLandRequestBs : IMasjidLandRequest
    {
        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;

        private readonly RequestSubmitModel _RequestSubmitModel;
        private readonly IGenericPattern<MasjidLandRequest> _tbl_MLR;
        private MasjidLandRequestModel _MasjidLandRequestModel;

        public MasjidLandRequestBs()
        {
            _tbl_MLR = new GenericPattern<MasjidLandRequest>();
            _MasjidLandRequestModel = new MasjidLandRequestModel();


            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModel = new RequestSubmitModel();

        }

        public List<MasjidLandRequestModel> MasjidLandRequestList()
        {
            List<MasjidLandRequestModel> _MLRList = new List<MasjidLandRequestModel>();
            var MLRData = _tbl_MLR.GetAll().ToList();
            _MLRList = (from item in MLRData
                        select new MasjidLandRequestModel
                        {

                            Id = item.Id,
                            ShortDescription = item.ShortDescription,
                            UserId = item.UserId,
                            UserName = (item.User != null) ? item.User.Name : string.Empty,
                            Location = item.Location,
                            Area = item.Area,
                            MasjidId = item.MasjidId,
                            MasjidName = (item.Masjid != null) ? item.Masjid.Name : string.Empty,
                            TimePeriod = item.TimePeriod,
                            AmountPaid = item.AmountPaid,
                            AmountNeeded = item.AmountNeeded,
                            LandArea = item.LandArea,
                            LandPrice = item.LandPrice,
                            PurchasingFrom = item.PurchasingFrom,
                            Doc1 = item.Doc1,
                            Doc2 = item.Doc2,
                            Doc3 = item.Doc3,
                            Pic1 = item.Pic1,
                            Pic2 = item.Pic2,
                            Pic3 = item.Pic3,
                            RequestSubmitId = item.RequestSubmitId,
                            //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                            Status = item.Status,
                            CreatedDate = item.CreatedDate,
                            RequestTypeId = item.RequestTypeId,
                            RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,
                        }).OrderByDescending(x => x.Id).ToList();
            return _MLRList;
        }

        public List<MasjidModel> MasjidList()
        {
            GenericPattern<Masjid> _tbl_Masjid = new GenericPattern<Masjid>();
            List<MasjidModel> _MasjidList = new List<MasjidModel>();
            var MasjidData = _tbl_Masjid.GetAll().ToList();
            _MasjidList = (from item in MasjidData
                           select new MasjidModel
                           {

                               Id = item.Id,
                               Name = item.Name,
                           }).OrderByDescending(x => x.Id).ToList();
            return _MasjidList;
        }

        public List<UserModel> UserList()
        {
            GenericPattern<User> _tbl_User = new GenericPattern<User>();
            List<UserModel> _UserList = new List<UserModel>();
            var UserData = _tbl_User.GetAll().ToList();
            _UserList = (from item in UserData
                         select new UserModel
                         {
                             Id = item.Id,
                             Name = item.Name,

                         }).OrderByDescending(x => x.Id).ToList();
            return _UserList;
        }

        public List<RequestTypeModel> RequestTypeList()
        {
            GenericPattern<RequestType> _tbl_RequestType = new GenericPattern<RequestType>();
            List<RequestTypeModel> _RequestTypeModelList = new List<RequestTypeModel>();
            var RequestTypeData = _tbl_RequestType.GetAll().ToList();
            _RequestTypeModelList = (from item in RequestTypeData
                                     select new RequestTypeModel
                                     {
                                         Id = item.Id,
                                         Name = item.Name,

                                     }).OrderByDescending(x => x.Id).ToList();
            return _RequestTypeModelList;
        }

        public List<RequestSubmitModel> RequestSubmitList()
        {
            GenericPattern<RequestSubmit> _tbl_RequestSubmit = new GenericPattern<RequestSubmit>();
            List<RequestSubmitModel> _RequestSubmitModelList = new List<RequestSubmitModel>();
            var RequestSubmitData = _tbl_RequestSubmit.GetAll().ToList();
            _RequestSubmitModelList = (from item in RequestSubmitData
                                       select new RequestSubmitModel
                                       {
                                           //Id = item.Id,
                                           //Name = item.Name,

                                       }).OrderByDescending(x => x.Id).ToList();
            return _RequestSubmitModelList;
        }

        public MasjidLandRequestModel GetDetails(MasjidLandRequestModel model)
        {
            model = model ?? new MasjidLandRequestModel();
            if (model.Id != 0)
            {
                model.MasjidLists = MasjidList();
                model.RequestTypeLists = RequestTypeList();
                model.UserLists = UserList();
                model.MasjidLandRequestLists = MasjidLandRequestList();
            }
            model.MasjidLandRequestLists = MasjidLandRequestList();

            return model;

        }

        public int Save(MasjidLandRequestModel model)
        {

            MasjidLandRequest _tbl_mlr = new MasjidLandRequest(model);

            _RequestSubmitModel.ShortDesc = model.ShortDescription;
            _RequestSubmitModel.UserId = model.UserId;
            _RequestSubmitModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            _RequestSubmitModel.RequestTypeId = model.RequestTypeId;
            RequestSubmit _requestSubmit = new RequestSubmit(_RequestSubmitModel);

            if (_tbl_mlr.Id != null && _tbl_mlr.Id != 0)
            {
                _tbl_mlr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_MLR.Update(_tbl_mlr);
            }
            else
            {
                _requestSubmit = _RequestSubmit.Insert(_requestSubmit);
                _tbl_mlr.RequestSubmitId = _requestSubmit.Id;
                _tbl_mlr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_mlr = _tbl_MLR.Insert(_tbl_mlr);
            }


            return _tbl_mlr.Id;
        }

        public MasjidLandRequestModel GetById(int id)
        {
            MasjidLandRequestModel _MasjidLandRequestModel = new MasjidLandRequestModel();
            var MLRbyId = _tbl_MLR.GetById(id);
            MLRbyId = MLRbyId ?? new MasjidLandRequest();
            _MasjidLandRequestModel = new MasjidLandRequestModel
            {
                Id = MLRbyId.Id,
                ShortDescription = MLRbyId.ShortDescription,
                UserId = MLRbyId.UserId,
                UserName = (MLRbyId.User != null) ? MLRbyId.User.UserName : string.Empty,
                Location = MLRbyId.Location,
                Area = MLRbyId.Area,
                MasjidId = MLRbyId.MasjidId,
                MasjidName = (MLRbyId.Masjid != null) ? MLRbyId.Masjid.Name : string.Empty,
                TimePeriod = MLRbyId.TimePeriod,
                AmountPaid = MLRbyId.AmountPaid,
                AmountNeeded = MLRbyId.AmountNeeded,
                LandArea = MLRbyId.LandArea,
                LandPrice = MLRbyId.LandPrice,
                PurchasingFrom = MLRbyId.PurchasingFrom,
                Doc1 = MLRbyId.Doc1,
                Doc2 = MLRbyId.Doc2,
                Doc3 = MLRbyId.Doc3,
                Pic1 = MLRbyId.Pic1,
                Pic2 = MLRbyId.Pic2,
                Pic3 = MLRbyId.Pic3,
                RequestSubmitId = MLRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MLRbyId.Status,
                CreatedDate = MLRbyId.CreatedDate,
                RequestTypeId = MLRbyId.RequestTypeId,
                RequestTypeName = (MLRbyId.RequestType != null) ? MLRbyId.RequestType.Name : string.Empty,
            };
            _MasjidLandRequestModel.RequestCommentList = new RequestCommentBs().BoardCommentList(id);
            _MasjidLandRequestModel.ApprovedList = new RequestApproveRejectBs().ApproveRejectDisplay(id);
            return _MasjidLandRequestModel;


        }

        public MasjidLandRequestModel GetMasjidLandById(int id, int userid)
        {
            MasjidLandRequestModel _MasjidLandRequestModel = new MasjidLandRequestModel();
            var MLRbyId = _tbl_MLR.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            MLRbyId = MLRbyId ?? new MasjidLandRequest();
            _MasjidLandRequestModel = new MasjidLandRequestModel
            {
                Id = MLRbyId.Id,
                ShortDescription = MLRbyId.ShortDescription,
                UserId = MLRbyId.UserId,
                UserName = (MLRbyId.User != null) ? MLRbyId.User.UserName : string.Empty,
                Location = MLRbyId.Location,
                Area = MLRbyId.Area,
                MasjidId = MLRbyId.MasjidId,
                MasjidName = (MLRbyId.Masjid != null) ? MLRbyId.Masjid.Name : string.Empty,
                TimePeriod = MLRbyId.TimePeriod,
                AmountPaid = MLRbyId.AmountPaid,
                AmountNeeded = MLRbyId.AmountNeeded,
                LandArea = MLRbyId.LandArea,
                LandPrice = MLRbyId.LandPrice,
                PurchasingFrom = MLRbyId.PurchasingFrom,
                Doc1 = MLRbyId.Doc1,
                Doc2 = MLRbyId.Doc2,
                Doc3 = MLRbyId.Doc3,
                Pic1 = MLRbyId.Pic1,
                Pic2 = MLRbyId.Pic2,
                Pic3 = MLRbyId.Pic3,
                RequestSubmitId = MLRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MLRbyId.Status,
                CreatedDate = MLRbyId.CreatedDate,
                RequestTypeId = MLRbyId.RequestTypeId,
                RequestTypeName = (MLRbyId.RequestType != null) ? MLRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            _MasjidLandRequestModel.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            _MasjidLandRequestModel.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MasjidLandRequestModel.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();
            _MasjidLandRequestModel.AlreadyExistsInMemberOpinion = _MasjidLandRequestModel.ApprovedList == null ? false : _MasjidLandRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MLRbyId.RequestSubmitId).Any();
            if (_MasjidLandRequestModel.AlreadyExistsInMemberOpinion)
            {
                _MasjidLandRequestModel.MemberOpinionId = _MasjidLandRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MLRbyId.RequestSubmitId).FirstOrDefault().Id;
                _MasjidLandRequestModel.IsAgreed = _MasjidLandRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MLRbyId.RequestSubmitId).FirstOrDefault().IsApproved;
                _MasjidLandRequestModel.LikeStatus = _MasjidLandRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MLRbyId.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();

            _MasjidLandRequestModel.PannelMemberInvolved = panelobject.InvolveList(id).ToList();

            return _MasjidLandRequestModel;


        }

        public MasjidLandRequestModel GetMasjidLandById(int id)
        {
            MasjidLandRequestModel _MasjidLandRequestModel = new MasjidLandRequestModel();
            var MLRbyId = _tbl_MLR.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            MLRbyId = MLRbyId ?? new MasjidLandRequest();
            _MasjidLandRequestModel = new MasjidLandRequestModel
            {
                Id = MLRbyId.Id,
                ShortDescription = MLRbyId.ShortDescription,
                UserId = MLRbyId.UserId,
                UserName = (MLRbyId.User != null) ? MLRbyId.User.UserName : string.Empty,
                Location = MLRbyId.Location,
                Area = MLRbyId.Area,
                MasjidId = MLRbyId.MasjidId,
                MasjidName = (MLRbyId.Masjid != null) ? MLRbyId.Masjid.Name : string.Empty,
                TimePeriod = MLRbyId.TimePeriod,
                AmountPaid = MLRbyId.AmountPaid,
                AmountNeeded = MLRbyId.AmountNeeded,
                LandArea = MLRbyId.LandArea,
                LandPrice = MLRbyId.LandPrice,
                PurchasingFrom = MLRbyId.PurchasingFrom,
                Doc1 = MLRbyId.Doc1,
                Doc2 = MLRbyId.Doc2,
                Doc3 = MLRbyId.Doc3,
                Pic1 = MLRbyId.Pic1,
                Pic2 = MLRbyId.Pic2,
                Pic3 = MLRbyId.Pic3,
                RequestSubmitId = MLRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MLRbyId.Status,
                CreatedDate = MLRbyId.CreatedDate,
                RequestTypeId = MLRbyId.RequestTypeId,
                RequestTypeName = (MLRbyId.RequestType != null) ? MLRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var GetCommentList = obj.BoardCommentList(id).ToList();
            _MasjidLandRequestModel.RequestCommentList = GetCommentList;
            var PannelComments = obj.PanelCommentList(id).ToList();
            _MasjidLandRequestModel.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MasjidLandRequestModel.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();

            PanelInvolveBs panelobject = new PanelInvolveBs();

            _MasjidLandRequestModel.PannelMemberInvolved = panelobject.InvolveList(id).ToList();

            return _MasjidLandRequestModel;

        }
    }
}