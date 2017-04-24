using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
    public partial class MasjidExtensionRequestModel
    {
        public int Id { get; set; }

        public string ShortDescription { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int IsPanelHead { get; set; }

        public int IsPanelMember { get; set; }

        public string Location { get; set; }

        public string Area { get; set; }

        public int? MasjidId { get; set; }
        public string MasjidName { get; set; }


        public string ConstructionCost { get; set; }

        public string ExistingFloors { get; set; }

        public decimal? AmountNeeded { get; set; }

        public string Engineer { get; set; }

        public byte[] Elevation { get; set; }
        public string Comment { get; set; }


        public byte[] Paln { get; set; }

        public byte[] Doc1 { get; set; }

        public byte[] Doc2 { get; set; }

        public byte[] Doc3 { get; set; }

        public byte[] Pic1 { get; set; }

        public byte[] Pic2 { get; set; }

        public byte[] Pic3 { get; set; }

        public int? RequestSubmitId { get; set; }
        public string RequestSubmitName { get; set; }


        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }


        public List<MasjidModel> MasjidLists { get; set; }

        public List<RequestSubmitModel> RequestSubmitLists { get; set; }

        public List<RequestTypeModel> RequestTypeLists { get; set; }

        public List<UserModel> UserLists { get; set; }

        public List<MasjidExtensionRequestModel> MasjidExtensionRequestLists { get; set; }
        public List<RequestCommentModel> RequestCommentList { get; set; }

        public List<RequestCommentModel> BoardCommentList { get; set; }

        public List<RequestCommentModel> PanelCommentList { get; set; }

        public List<RequestApproveModel> ApprovedList { get; set; }

        public List<PanelInvolvementModel> PannelMemberInvolved { get; set; }

        public bool AlreadyExistsInMemberOpinion { get; set; }
        public int MemberOpinionId { get; set; }
        public bool? IsAgreed { get; set; }
        public bool? LikeStatus { get; set; }
        public bool? IsObject { get; set; }
        public bool? IsObjectClicked { get; set; }
        public bool IsPanelInvolved { get; set; }
        public bool IsPanelHeadUser { get; set; }
    }
}
