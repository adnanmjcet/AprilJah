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
    public class EventRequestBs
    {
        private readonly IGenericPattern<EventRequest> _EventRequest;
        private readonly IGenericPattern<EventRequestDetail> _EventRequestDetail;
        private readonly IGenericPattern<EventMaster> _EventMaster;
        private readonly IGenericPattern<RequestSubmit> _RequestSubmit;


        public EventRequestBs()
        {
            _EventRequest = new GenericPattern<EventRequest>();
            _EventRequestDetail = new GenericPattern<EventRequestDetail>();
            _EventMaster = new GenericPattern<EventMaster>();

        }

        public EventRequestModel GetById(int id)
        {
            return _EventRequest.GetAll().Where(x => x.Id == id).Select(x => new EventRequestModel
            {
                Id = x.Id,
                EventName = x.EventName,
                EventTypeId = x.EventType,
                Description = x.Description,
                TotalSpeakers = x.TotalSpeakers,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                Venu = x.Venu,
                UserId = x.UserId,
                RequestSubmitId = x.RequestSubmitId,
                CreatedDate = x.CreatedDate
            }).FirstOrDefault();
        }

        public EventRequestDetailModel GetEventDetailsId(int id)
        {
            return _EventRequestDetail.GetAll().Where(x => x.Id == id).Select(x => new EventRequestDetailModel
            {
                Id = x.Id,
                SpeakerName = x.SpeakerName,
                Date = x.Date,
                Time = x.Time,
                CreatedDate = x.CreatedDate,
                EventRequestId = x.EventRequestId,
            }).FirstOrDefault();
        }

        public int Save(EventRequestModel model)
        {
            EventRequest _eventRequest = new EventRequest(model);
            if (model.Id != null && model.Id != 0)
            {
                _EventRequest.Update(_eventRequest);

            }
            else
            {
                RequestSubmitModel res = new RequestSubmitModel();
                res.RequestTypeId = 9;
                res.UserId = model.UserId;
                res.ShortDesc = model.Description;

                int id = new RequestSubmitBs().Save(res);
                _eventRequest.RequestSubmitId = id;
                _eventRequest.Poster = model.Poster;
                _eventRequest.CreatedDate = System.DateTime.Now;
                _eventRequest.RequestTypeId = 9;
                _EventRequest.Insert(_eventRequest);
            }

            return _eventRequest.Id;
        }

        public int SaveEventDetails(EventRequestDetailModel model)
        {
            EventRequestDetail _eventRequestDetails = new EventRequestDetail(model);
            if (model.Id != null && model.Id != 0)
            {
                _EventRequestDetail.Update(_eventRequestDetails);

            }
            else
            {
                //_eventRequest.IsDelete = false;
                _eventRequestDetails.CreatedDate = System.DateTime.Now;
                _EventRequestDetail.Insert(_eventRequestDetails);
            }

            return _eventRequestDetails.Id;
        }

        public List<EventRequestModel> GetAllEvents()
        {
            return _EventRequest.GetAll().Select(x => new EventRequestModel
            {
                Id = x.Id,
                EventName = x.EventName,
                EventTypeId = x.EventType,
                Description = x.Description,
                TotalSpeakers = x.TotalSpeakers,
                EventTypeName = x.EventMaster.Name,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                Venu = x.Venu,
                UserId = x.UserId,
                RequestSubmitId = x.RequestSubmitId,
                CreatedDate = x.CreatedDate

            }).ToList();
        }

        public List<EventRequestDetailModel> GetAllEventDetails()
        {
            return _EventRequestDetail.GetAll().Select(x => new EventRequestDetailModel
            {
                Id = x.Id,
                SpeakerName = x.SpeakerName,
                Date = x.Date,
                Time = x.Time,
                Topic = x.Topic,
                CreatedDate = x.CreatedDate,
                EventRequestId = x.EventRequestId

            }).ToList();
        }

        public List<EventMasterModel> GetAllEventMasterList()
        {
            return _EventMaster.GetAll().Select(x => new EventMasterModel
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();
        }


        public EventRequestModel GetByRequestSubmitIdBoard(int id, int userid)
        {
            EventRequestModel varList = new EventRequestModel();
            var item = _EventRequest.GetAll().Where(x => x.RequestSubmitId == id).FirstOrDefault();
            item = item ?? new EventRequest();
            varList = new EventRequestModel
            {

                Id = item.Id,
                EventName = item.EventName,
                Description = item.Description,
                TotalSpeakers = item.TotalSpeakers,
                Poster = item.Poster,
                FromDate = item.FromDate,
                ToDate = item.ToDate,
                CreatedDate = item.CreatedDate,
                Venu = item.Venu,
                UserId = item.UserId,
                UserName = (item.User != null) ? item.User.Name : string.Empty,
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
            varList.AlreadyExistsInMemberOpinion = varList.ApprovedList == null ? false : varList.ApprovedList.Where(m => m.UserTypeId == userid && m.RequestSubmitId == item.RequestSubmitId).Any();
            if (varList.AlreadyExistsInMemberOpinion)
            {
                varList.MemberOpinionId = varList.ApprovedList.Where(m => m.UserTypeId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().Id;
                varList.IsAgreed = varList.ApprovedList.Where(m => m.UserTypeId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().IsApproved;
                varList.LikeStatus = varList.ApprovedList.Where(m => m.UserTypeId == userid && m.RequestSubmitId == item.RequestSubmitId).FirstOrDefault().LikeStatus;
            }
            PanelInvolveBs panelobject = new PanelInvolveBs();

            varList.PannelMemberInvolved = panelobject.InvolveList(id).ToList();
            return varList;
        }

    }
}
