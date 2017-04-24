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
    public class MadarsaExtensionRequestBs : IMadarsaExtenstionRequest
    {
        private readonly IGenericPattern<MadarsaExtensionRequest> tbl_MadarsaExtensionRequest;
        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;

        private readonly RequestSubmitModel _RequestSubmitModel;

        public MadarsaExtensionRequestBs()
        {
            tbl_MadarsaExtensionRequest = new GenericPattern<MadarsaExtensionRequest>();
            _RequestSubmit = new GenericPattern<RequestSubmit>();
            _RequestSubmitModel = new RequestSubmitModel();
        }


        public List<MadarsaExtensionRequestModel> MadarsaExtensionRequestList()
        {
            List<MadarsaExtensionRequestModel> _varList = new List<MadarsaExtensionRequestModel>();
            var varData = tbl_MadarsaExtensionRequest.GetAll().ToList();
            _varList = (from item in varData
                        select new MadarsaExtensionRequestModel
                        {
                            Id = item.Id,
                            ShortDescription = item.ShortDescription,
                            Location = item.Location,
                            Area = item.Area,
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
                            Status = item.Status,
                            CreatedDate = item.CreatedDate,
                            // CreatedBy = item.CreatedBy,

                            UserId = item.UserId,
                            UserName = (item.User != null) ? item.User.Name : string.Empty,

                            MadarsaId = item.MadarsaId,
                            MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                            RequestTypeId = item.RequestTypeId,
                            RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                            RequestSubmitId = item.RequestSubmitId,
                            //  RequestSubmitId


                        }).OrderByDescending(x => x.Id).ToList();
            return _varList;
        }

        public MadarsaExtensionRequestModel GetById(int id)
        {
            MadarsaExtensionRequestModel varList = new MadarsaExtensionRequestModel();
            var item = tbl_MadarsaExtensionRequest.GetById(id);
            item = item ?? new MadarsaExtensionRequest();
            varList = new MadarsaExtensionRequestModel
            {

                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
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
                Status = item.Status,
                CreatedDate = item.CreatedDate,
                // CreatedBy = item.CreatedBy,

                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,

                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                RequestSubmitId = item.RequestSubmitId,
                //  RequestSubmitId
            };
            varList.BoardCommentList = new RequestCommentBs().BoardCommentList(id);
            varList.ApprovedList = new RequestApproveRejectBs().ApproveRejectDisplay(id);

            return varList;
        }

        public MadarsaExtensionRequestModel GetByRequestSubmitId(int id)
        {
            MadarsaExtensionRequestModel varList = new MadarsaExtensionRequestModel();
            var item = tbl_MadarsaExtensionRequest.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            item = item ?? new MadarsaExtensionRequest();
            varList = new MadarsaExtensionRequestModel
            {

                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
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
                Status = item.Status,
                CreatedDate = item.CreatedDate,
                // CreatedBy = item.CreatedBy,

                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,

                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                RequestSubmitId = item.RequestSubmitId,
                //  RequestSubmitId
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

        public MadarsaExtensionRequestModel GetByRequestSubmitId(int id,int userid)
        {
            MadarsaExtensionRequestModel varList = new MadarsaExtensionRequestModel();
            var item = tbl_MadarsaExtensionRequest.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
           
            item = item ?? new MadarsaExtensionRequest();
            varList = new MadarsaExtensionRequestModel
            {

                Id = item.Id,
                ShortDescription = item.ShortDescription,
                Location = item.Location,
                Area = item.Area,
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
                Status = item.Status,
                CreatedDate = item.CreatedDate,
                // CreatedBy = item.CreatedBy,

                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,

                MadarsaId = item.MadarsaId,
                MadarsaName = (item.Madarsa != null) ? item.Madarsa.Name : string.Empty,

                RequestTypeId = item.RequestTypeId,
                RequestTypeName = (item.RequestType != null) ? item.RequestType.Name : string.Empty,

                RequestSubmitId = item.RequestSubmitId,
                //  RequestSubmitId
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
                varList.IsAgreed= varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().IsApproved;
                varList.LikeStatus = varList.ApprovedList.Where(m => m.UserId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();
          
            varList.PannelMemberInvolved = panelobject.InvolveList(id).ToList();
            return varList;
        }

        public MadarsaExtensionRequestModel GetDetails(MadarsaExtensionRequestModel model)
        {
            model = model ?? new MadarsaExtensionRequestModel();
            if (model.Id != 0)
            {
                model.MadarsaExtensionRequestModelList = MadarsaExtensionRequestList();
                model.UserModelList = UserList();
                model.MadarsaModelList = MadarsaList();
                model.RequestSubmitModelList = RequestSubmitList();
                model.RequestTypeModelList = RequestTypeList();
            }
            model.MadarsaExtensionRequestModelList = MadarsaExtensionRequestList();

            return model;
        }

        public int Save(MadarsaExtensionRequestModel model)
        {

            MadarsaExtensionRequest _tblList = new MadarsaExtensionRequest(model);

            _RequestSubmitModel.ShortDesc = model.ShortDescription;
            _RequestSubmitModel.UserId = model.UserId;
            _RequestSubmitModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
            _RequestSubmitModel.RequestTypeId = model.RequestTypeId;
            RequestSubmit _requestSubmit = new RequestSubmit(_RequestSubmitModel);

            if (_tblList.Id != null && _tblList.Id != 0)
            {
                _tblList.CreatedDate = System.DateTime.Now;
                //_tblList.CreatedBy = 1;
                tbl_MadarsaExtensionRequest.Update(_tblList);
            }
            else
            {
                _requestSubmit = _RequestSubmit.Insert(_requestSubmit);
                _tblList.RequestSubmitId = _requestSubmit.Id;
                _tblList.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
               // _tblList.CreatedBy = 1;
                _tblList = tbl_MadarsaExtensionRequest.Insert(_tblList);
            }


            return _tblList.Id;
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
                              //Id = item.Id,
                              // Name = item.Name,

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
