using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public class EventRequestModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public string TotalSpeakers { get; set; }

        public int? EventTypeId { get; set; }

        public string Venu { get; set; }

        public byte[] Poster { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? UserId { get; set; }

        public int? RequestSubmitId { get; set; }

        public int? RequestTypeId { get; set; }

        public string UserName { get; set; }
        public string EventTypeName { get; set; }
        public string RequestTypeName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<EventMasterModel> EventTypeMaster { get; set; }


        public List<EventRequestModel> EventRequestModelList { get; set; }

        public List<EventRequestDetailModel> EventRequestDetailList { get; set; }

        public List<EventMasterModel> EventMasterModelList { get; set; }

        public List<RequestSubmitModel> RequestSubmitModelList { get; set; }

        public List<RequestTypeModel> RequestTypeModelList { get; set; }

        public List<UserModel> UserModelList { get; set; }

        public List<RequestApproveModel> ApprovedList { get; set; }

        public List<RequestCommentModel> RequestCommentList { get; set; }

        public List<RequestCommentModel> BoardCommentList { get; set; }

        public List<RequestCommentModel> PanelCommentList { get; set; }


        public List<PanelInvolvementModel> PannelMemberInvolved { get; set; }

        public List<RequestApproveModel> PaannelMemberLikeDisLike { get; set; }

        public bool AlreadyExistsInMemberOpinion { get; set; }
        public int MemberOpinionId { get; set; }
        public bool? IsAgreed { get; set; }
        public bool? LikeStatus { get; set; }
        public bool? IsObject { get; set; }
        public bool? IsObjectClicked { get; set; }
        public bool? IsPanelInvolved { get; set; }
        public bool? IsPanelHeadUser { get; set; }

        public bool? IsAmeerApproved { get; set; }
        public List<RequestCommentModel> AdminCommentList { get; set; }
    }
}
