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
    public class MasjidConstructionRequestBs : IMasjidConstructionRequest
    {
        private readonly IGenericPattern<MasjidConstructionRequest> _tbl_MCR;
        private MasjidConstructionRequestModel _MasjidConstructionRequestModel;

        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;

        private readonly RequestSubmitModel _RequestSubmitModel;

        public MasjidConstructionRequestBs()
        {
            _tbl_MCR = new GenericPattern<MasjidConstructionRequest>();
            _MasjidConstructionRequestModel = new MasjidConstructionRequestModel();

            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModel = new RequestSubmitModel();
        }


        public List<MasjidConstructionRequestModel> MasjidConstructionRequestList()
        {
            List<MasjidConstructionRequestModel> _MCRList = new List<MasjidConstructionRequestModel>();
            var MCRData = _tbl_MCR.GetAll().ToList();
            _MCRList = (from item in MCRData
                        select new MasjidConstructionRequestModel
                        {

                            Id = item.Id,
                            ShortDescription = item.ShortDescription,
                            UserId = item.UserId,
                            UserName = (item.User != null) ? item.User.Name : string.Empty,
                            Location = item.Location,
                            Area = item.Area,
                            MasjidId = item.MasjidId,
                            MasjidName = (item.Masjid != null) ? item.Masjid.Name : string.Empty,
                            ConstructionCost = Convert.ToInt32(item.ConstructionCost),
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
            return _MCRList;
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
                                           Id = item.Id,
                                           // Name = item.Name,

                                       }).OrderByDescending(x => x.Id).ToList();
            return _RequestSubmitModelList;
        }

        public MasjidConstructionRequestModel GetDetails(MasjidConstructionRequestModel model)
        {
            model = model ?? new MasjidConstructionRequestModel();
            if (model.Id != 0)
            {
                model.MasjidLists = MasjidList();
                model.RequestTypeLists = RequestTypeList();
                model.UserLists = UserList();
                model.MasjidConstructionRequestLists = MasjidConstructionRequestList();
            }
            model.MasjidConstructionRequestLists = MasjidConstructionRequestList();

            return model;

        }

        public int Save(MasjidConstructionRequestModel model)
        {

            MasjidConstructionRequest _tbl_mcr = new MasjidConstructionRequest(model);

            _RequestSubmitModel.ShortDesc = model.ShortDescription;
            _RequestSubmitModel.UserId = model.UserId;
            _RequestSubmitModel.RequestTypeId = model.RequestTypeId;
            RequestSubmit _requestSubmit = new RequestSubmit(_RequestSubmitModel);
            _RequestSubmitModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            if (_tbl_mcr.Id != null && _tbl_mcr.Id != 0)
            {
                _tbl_mcr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_MCR.Update(_tbl_mcr);
            }
            else
            {
                _requestSubmit = _RequestSubmit.Insert(_requestSubmit);
                _tbl_mcr.RequestSubmitId = _requestSubmit.Id;
                _tbl_mcr.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                //_tblList.CreatedBy = 1;
                _tbl_mcr = _tbl_MCR.Insert(_tbl_mcr);
            }

            return _tbl_mcr.Id;
        }

        public MasjidConstructionRequestModel GetById(int id)
        {
            MasjidConstructionRequestModel _MasjidConstructionRequest = new MasjidConstructionRequestModel();
            var MCRbyId = _tbl_MCR.GetById(id);
            MCRbyId = MCRbyId ?? new MasjidConstructionRequest();
            _MasjidConstructionRequestModel = new MasjidConstructionRequestModel
            {
                Id = MCRbyId.Id,
                ShortDescription = MCRbyId.ShortDescription,
                UserId = MCRbyId.UserId,
                UserName = (MCRbyId.User != null) ? MCRbyId.User.UserName : string.Empty,
                Location = MCRbyId.Location,
                Area = MCRbyId.Area,
                MasjidId = MCRbyId.MasjidId,
                MasjidName = (MCRbyId.Masjid != null) ? MCRbyId.Masjid.Name : string.Empty,
                ConstructionCost = Convert.ToInt32(MCRbyId.ConstructionCost),
                ExistingFloors = MCRbyId.ExistingFloors,
                AmountNeeded = MCRbyId.AmountNeeded,
                Engineer = MCRbyId.Engineer,
                Elevation = MCRbyId.Elevation,
                Paln = MCRbyId.Paln,
                Doc1 = MCRbyId.Doc1,
                Doc2 = MCRbyId.Doc2,
                Doc3 = MCRbyId.Doc3,
                Pic1 = MCRbyId.Pic1,
                Pic2 = MCRbyId.Pic2,
                Pic3 = MCRbyId.Pic3,
                RequestSubmitId = MCRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MCRbyId.Status,
                CreatedDate = MCRbyId.CreatedDate,
                RequestTypeId = MCRbyId.RequestTypeId,
                RequestTypeName = (MCRbyId.RequestType != null) ? MCRbyId.RequestType.Name : string.Empty,
            };

            _MasjidConstructionRequestModel.RequestCommentList = new RequestCommentBs().BoardCommentList(id);
            _MasjidConstructionRequestModel.ApprovedList = new RequestApproveRejectBs().ApproveRejectDisplay(id);

            return _MasjidConstructionRequestModel;

        }

        public MasjidConstructionRequestModel GetByRequestId(int id)
        {
            MasjidConstructionRequestModel _MConstructionReq = new MasjidConstructionRequestModel();
            var MCRbyId = _tbl_MCR.GetAll().Where(m => m.RequestSubmitId == id).FirstOrDefault();
            MCRbyId = MCRbyId ?? new MasjidConstructionRequest();
            _MConstructionReq = new MasjidConstructionRequestModel
            {
                Id = MCRbyId.Id,
                ShortDescription = MCRbyId.ShortDescription,
                UserId = MCRbyId.UserId,
                UserName = (MCRbyId.User != null) ? MCRbyId.User.UserName : string.Empty,
                Location = MCRbyId.Location,
                Area = MCRbyId.Area,
                MasjidId = MCRbyId.MasjidId,
                MasjidName = (MCRbyId.Masjid != null) ? MCRbyId.Masjid.Name : string.Empty,
                ConstructionCost = Convert.ToInt32(MCRbyId.ConstructionCost),
                ExistingFloors = MCRbyId.ExistingFloors,
                AmountNeeded = MCRbyId.AmountNeeded,
                Engineer = MCRbyId.Engineer,
                Elevation = MCRbyId.Elevation,
                Paln = MCRbyId.Paln,
                Doc1 = MCRbyId.Doc1,
                Doc2 = MCRbyId.Doc2,
                Doc3 = MCRbyId.Doc3,
                Pic1 = MCRbyId.Pic1,
                Pic2 = MCRbyId.Pic2,
                Pic3 = MCRbyId.Pic3,
                RequestSubmitId = MCRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MCRbyId.Status,
                CreatedDate = MCRbyId.CreatedDate,
                RequestTypeId = MCRbyId.RequestTypeId,
                RequestTypeName = (MCRbyId.RequestType != null) ? MCRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            _MConstructionReq.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            _MConstructionReq.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MConstructionReq.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();

            PanelInvolveBs panelobject = new PanelInvolveBs();
            _MConstructionReq.PannelMemberInvolved = panelobject.InvolveList(id).ToList();

            return _MConstructionReq;

        }

        public MasjidConstructionRequestModel GetByRequestId(int id, int userid)
        {
            MasjidConstructionRequestModel _MConstructionReq = new MasjidConstructionRequestModel();
            var MCRbyId = _tbl_MCR.GetAll().Where(m => m.RequestSubmitId == id).FirstOrDefault();
            MCRbyId = MCRbyId ?? new MasjidConstructionRequest();
            _MConstructionReq = new MasjidConstructionRequestModel
            {
                Id = MCRbyId.Id,
                ShortDescription = MCRbyId.ShortDescription,
                UserId = MCRbyId.UserId,
                UserName = (MCRbyId.User != null) ? MCRbyId.User.UserName : string.Empty,
                Location = MCRbyId.Location,
                Area = MCRbyId.Area,
                MasjidId = MCRbyId.MasjidId,
                MasjidName = (MCRbyId.Masjid != null) ? MCRbyId.Masjid.Name : string.Empty,
                ConstructionCost = Convert.ToInt32(MCRbyId.ConstructionCost),
                ExistingFloors = MCRbyId.ExistingFloors,
                AmountNeeded = MCRbyId.AmountNeeded,
                Engineer = MCRbyId.Engineer,
                Elevation = MCRbyId.Elevation,
                Paln = MCRbyId.Paln,
                Doc1 = MCRbyId.Doc1,
                Doc2 = MCRbyId.Doc2,
                Doc3 = MCRbyId.Doc3,
                Pic1 = MCRbyId.Pic1,
                Pic2 = MCRbyId.Pic2,
                Pic3 = MCRbyId.Pic3,
                RequestSubmitId = MCRbyId.RequestSubmitId,
                //RequestSubmitName= (item.RequestSubmit != null) ? item.RequestSubmit.Name : string.Empty,
                Status = MCRbyId.Status,
                CreatedDate = MCRbyId.CreatedDate,
                RequestTypeId = MCRbyId.RequestTypeId,
                RequestTypeName = (MCRbyId.RequestType != null) ? MCRbyId.RequestType.Name : string.Empty,
            };
            RequestCommentBs obj = new RequestCommentBs();
            var BoardComments = obj.BoardCommentList(id).ToList();
            _MConstructionReq.BoardCommentList = BoardComments;

            var PannelComments = obj.PanelCommentList(id).ToList();
            _MConstructionReq.PanelCommentList = PannelComments;

            RequestApproveRejectBs obj1 = new RequestApproveRejectBs();
            _MConstructionReq.ApprovedList = obj1.ApproveRejectDisplay(id).ToList();
            _MConstructionReq.AlreadyExistsInMemberOpinion = _MConstructionReq.ApprovedList == null ? false : _MConstructionReq.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MCRbyId.RequestSubmitId).Any();
            if (_MConstructionReq.AlreadyExistsInMemberOpinion)
            {
                _MConstructionReq.MemberOpinionId = _MConstructionReq.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MCRbyId.RequestSubmitId).FirstOrDefault().Id;
                _MConstructionReq.IsAgreed = _MConstructionReq.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MCRbyId.RequestSubmitId).FirstOrDefault().IsApproved;
                _MConstructionReq.LikeStatus = _MConstructionReq.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == MCRbyId.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();

            _MConstructionReq.PannelMemberInvolved = panelobject.InvolveList(id).ToList();
           

            return _MConstructionReq;
        }
    }
}
