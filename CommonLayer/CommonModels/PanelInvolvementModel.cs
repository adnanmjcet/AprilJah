using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
  public class PanelInvolvementModel
    {
        public PanelInvolvementModel() { }
        public PanelInvolvementModel(MadarsaExtensionRequestModel obj,int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)obj.RequestSubmitId;
        }

        public PanelInvolvementModel(ExistingMadarsaOperationsRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;
           
        }


        public PanelInvolvementModel(NewMadarsaOperationsRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }
        public PanelInvolvementModel(MadarsaLandRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }
        public PanelInvolvementModel(MasjidExtensionRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }

        public PanelInvolvementModel(MasjidLandRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }
        public PanelInvolvementModel(MasjidConstructionRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }
        public PanelInvolvementModel(MasjidRenovationRequestModel model, int userId, int userTypeId)
        {
            UserTypeId = userTypeId;
            UserId = userId;
            RequestSubmitId = (Int32)model.RequestSubmitId;

        }
        public int Id { get; set; }

        public int UserTypeId { get; set; }

        public string UserTypeName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }


        public int RequestSubmitId { get; set; }

        
        public DateTime CreatedDate { get; set; }

        public List<RequestSubmitModel> RequestSubmitList { get; set; }

        public List<UserModel> UserList { get; set; }

        public List<UserTypeModel> UserTypeList { get; set; }
        public bool? IsObject { get; set; }
        public bool? IsObjectClicked { get; set; }
    }
}
