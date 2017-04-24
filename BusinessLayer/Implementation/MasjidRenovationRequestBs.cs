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
    public class MasjidRenovationRequestBs : IMasjidRenovationRequest
    {

        private readonly IGenericPattern<MasjidRenovationRequest> _tbl_MRR;
        private MasjidRenovationRequestModel _MasjidRenovationRequestModel;
        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;

        private readonly RequestSubmitModel _RequestSubmitModel;
        public MasjidRenovationRequestBs()
        {
            _tbl_MRR = new GenericPattern<MasjidRenovationRequest>();
            _MasjidRenovationRequestModel = new MasjidRenovationRequestModel();

            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModel = new RequestSubmitModel();
        }

        public List<MasjidRenovationRequestModel> MasjidRenovationRequestList()
        {
            List<MasjidRenovationRequestModel> _MRRList = new List<MasjidRenovationRequestModel>();
            var MRRData = _tbl_MRR.GetAll().ToList();
            _MRRList = (from item in MRRData
                        select new MasjidRenovationRequestModel
                        {

                            Id = item.Id,
                            ShortDescription = item.ShortDescription,
                            UserId = item.UserId,
                            UserName = (item.User != null) ? item.User.Name : string.Empty,
                            Location = item.Location,
                            Area = item.Area,
                            MasjidId = item.MasjidId,
                            MasjidName = (item.Masjid != null) ? item.Masjid.Name : string.Empty,
                            ConstructionCost = item.ConstructionCost,
                            ExistingFloors = item.ExistingFloors,
                            AmountNeeded = item.AmountNeeded,
                            Engineer = item.Engineer,
                            Elevation = item.Elevation,
                            Paln = item.Paln,
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
            return _MRRList;
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

        public MasjidRenovationRequestModel GetDetails(MasjidRenovationRequestModel model)
        {
            model = model ?? new MasjidRenovationRequestModel();
            if (model.Id != 0)
            {
                model.MasjidLists = MasjidList();
                model.RequestTypeLists = RequestTypeList();
                model.UserLists = UserList();
                model.MasjidRenovationRequestLists = MasjidRenovationRequestList();
            }
            model.MasjidRenovationRequestLists = MasjidRenovationRequestList();

            return model;

        }

        public int Save(MasjidRenovationRequestModel model)
        {

            MasjidRenovationRequest _tbl_mrr = new MasjidRenovationRequest(model);

            _RequestSubmitModel.ShortDesc = model.ShortDescription;
            _RequestSubmitModel.UserId = model.UserId;
            _RequestSubmitModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            _RequestSubmitModel.RequestTypeId = model.RequestTypeId;
            RequestSubmit _requestSubmit = new RequestSubmit(_RequestSubmitModel);

            if (_tbl_mrr.Id != null && _tbl_mrr.Id != 0)
            {
                _tbl_mrr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_MRR.Update(_tbl_mrr);
            }
            else
            {
                _requestSubmit = _RequestSubmit.Insert(_requestSubmit);
                _tbl_mrr.RequestSubmitId = _requestSubmit.Id;
                _tbl_mrr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_mrr = _tbl_MRR.Insert(_tbl_mrr);
            }


            return _tbl_mrr.Id;
        }

        public MasjidRenovationRequestModel GetById(int id)
        {
            MasjidRenovationRequestModel _MasjidRenovationRequestModel = new MasjidRenovationRequestModel();
            var MRRbyId = _tbl_MRR.GetById(id);
            MRRbyId = MRRbyId ?? new MasjidRenovationRequest();
            _MasjidRenovationRequestModel = new MasjidRenovationRequestModel
            {
                Id = MRRbyId.Id,
                ShortDescription = MRRbyId.ShortDescription,
                UserId = MRRbyId.UserId,
                UserName = (MRRbyId.User != null) ? MRRbyId.User.UserName : string.Empty,
                Location = MRRbyId.Location,
                Area = MRRbyId.Area,
                MasjidId = MRRbyId.MasjidId,
                MasjidName = (MRRbyId.Masjid != null) ? MRRbyId.Masjid.Name : string.Empty,
                ConstructionCost = MRRbyId.ConstructionCost,
                ExistingFloors = MRRbyId.ExistingFloors,
                AmountNeeded = MRRbyId.AmountNeeded,
                Engineer = MRRbyId.Engineer,
                Elevation = MRRbyId.Elevation,
                Paln = MRRbyId.Paln,
                Doc1 = MRRbyId.Doc1,
                Doc2 = MRRbyId.Doc2,
                Doc3 = MRRbyId.Doc3,
                Pic1 = MRRbyId.Pic1,
                Pic2 = MRRbyId.Pic2,
                Pic3 = MRRbyId.Pic3,
                RequestSubmitId = MRRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MRRbyId.Status,
                CreatedDate = MRRbyId.CreatedDate,
                RequestTypeId = MRRbyId.RequestTypeId,
                RequestTypeName = (MRRbyId.RequestType != null) ? MRRbyId.RequestType.Name : string.Empty,
            };
            _MasjidRenovationRequestModel.RequestCommentList = new RequestCommentBs().BoardCommentList(id);
            _MasjidRenovationRequestModel.ApprovedList = new RequestApproveRejectBs().ApproveRejectDisplay(id);
            return _MasjidRenovationRequestModel;
        }
        public MasjidRenovationRequestModel GetMasjidRenovationById(int id)
        {
            MasjidRenovationRequestModel _MasjidRenovationRequestModel = new MasjidRenovationRequestModel();
            var MRRbyId = _tbl_MRR.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            MRRbyId = MRRbyId ?? new MasjidRenovationRequest();
            _MasjidRenovationRequestModel = new MasjidRenovationRequestModel
            {
                Id = MRRbyId.Id,
                ShortDescription = MRRbyId.ShortDescription,
                UserId = MRRbyId.UserId,
                UserName = (MRRbyId.User != null) ? MRRbyId.User.UserName : string.Empty,
                Location = MRRbyId.Location,
                Area = MRRbyId.Area,
                MasjidId = MRRbyId.MasjidId,
                MasjidName = (MRRbyId.Masjid != null) ? MRRbyId.Masjid.Name : string.Empty,
                ConstructionCost = MRRbyId.ConstructionCost,
                ExistingFloors = MRRbyId.ExistingFloors,
                AmountNeeded = MRRbyId.AmountNeeded,
                Engineer = MRRbyId.Engineer,
                Elevation = MRRbyId.Elevation,
                Paln = MRRbyId.Paln,
                Doc1 = MRRbyId.Doc1,
                Doc2 = MRRbyId.Doc2,
                Doc3 = MRRbyId.Doc3,
                Pic1 = MRRbyId.Pic1,
                Pic2 = MRRbyId.Pic2,
                Pic3 = MRRbyId.Pic3,
                RequestSubmitId = MRRbyId.RequestSubmitId,
              
                Status = MRRbyId.Status,
                CreatedDate = MRRbyId.CreatedDate,
                RequestTypeId = MRRbyId.RequestTypeId,
                RequestTypeName = (MRRbyId.RequestType != null) ? MRRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            _MasjidRenovationRequestModel.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            _MasjidRenovationRequestModel.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MasjidRenovationRequestModel.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();

            PanelInvolveBs panelobject = new PanelInvolveBs();
            _MasjidRenovationRequestModel.PannelMemberInvolved = panelobject.InvolveList(id).ToList();

            return _MasjidRenovationRequestModel;

        }
        public MasjidRenovationRequestModel GetMasjidRenovationById(int id, int userid)
        {
            MasjidRenovationRequestModel _MasjidRenovationRequestModel = new MasjidRenovationRequestModel();
            var MRRbyId = _tbl_MRR.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            MRRbyId = MRRbyId ?? new MasjidRenovationRequest();
            _MasjidRenovationRequestModel = new MasjidRenovationRequestModel
            {
                Id = MRRbyId.Id,
                ShortDescription = MRRbyId.ShortDescription,
                UserId = MRRbyId.UserId,
                UserName = (MRRbyId.User != null) ? MRRbyId.User.UserName : string.Empty,
                Location = MRRbyId.Location,
                Area = MRRbyId.Area,
                MasjidId = MRRbyId.MasjidId,
                MasjidName = (MRRbyId.Masjid != null) ? MRRbyId.Masjid.Name : string.Empty,
                ConstructionCost = MRRbyId.ConstructionCost,
                ExistingFloors = MRRbyId.ExistingFloors,
                AmountNeeded = MRRbyId.AmountNeeded,
                Engineer = MRRbyId.Engineer,
                Elevation = MRRbyId.Elevation,
                Paln = MRRbyId.Paln,
                Doc1 = MRRbyId.Doc1,
                Doc2 = MRRbyId.Doc2,
                Doc3 = MRRbyId.Doc3,
                Pic1 = MRRbyId.Pic1,
                Pic2 = MRRbyId.Pic2,
                Pic3 = MRRbyId.Pic3,
                RequestSubmitId = MRRbyId.RequestSubmitId,
              
                Status = MRRbyId.Status,
                CreatedDate = MRRbyId.CreatedDate,
                RequestTypeId = MRRbyId.RequestTypeId,
                RequestTypeName = (MRRbyId.RequestType != null) ? MRRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            _MasjidRenovationRequestModel.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            _MasjidRenovationRequestModel.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MasjidRenovationRequestModel.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();
            _MasjidRenovationRequestModel.AlreadyExistsInMemberOpinion = _MasjidRenovationRequestModel.ApprovedList == null ? false : _MasjidRenovationRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MRRbyId.RequestSubmitId).Any();
            if (_MasjidRenovationRequestModel.AlreadyExistsInMemberOpinion)
            {
                _MasjidRenovationRequestModel.MemberOpinionId = _MasjidRenovationRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MRRbyId.RequestSubmitId).FirstOrDefault().Id;
                _MasjidRenovationRequestModel.IsAgreed = _MasjidRenovationRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MRRbyId.RequestSubmitId).FirstOrDefault().IsApproved;
                _MasjidRenovationRequestModel.LikeStatus = _MasjidRenovationRequestModel.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MRRbyId.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();

            _MasjidRenovationRequestModel.PannelMemberInvolved = panelobject.InvolveList(id).ToList();

            return _MasjidRenovationRequestModel;

        }
    }
}
