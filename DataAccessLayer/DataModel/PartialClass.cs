using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;

namespace DataAccessLayer.DataModel
{
    class PartialClass
    {
    }

    public partial class RequestLike

    {
        public RequestLike()
        {

        }
        public RequestLike(RequestLikeModel item)
        {
            Id = item.Id;
            UserId = item.UserId;
            RequestSubmitId = item.RequestSubmitId;
            IsLike = item.IsLike;
            UserTypeId = item.UserTypeId;
            CreatedDate = item.CreatedDate;
        }
    }
    public partial class Volunteer
    {
        public Volunteer()
        {

        }
        public Volunteer(VolunteerModel item)
        {
            Id = item.Id;
            Name = item.Name;
            Email = item.Email;
            Contact = item.Contact;
            CreatedDate = Convert.ToDateTime(item.CreatedDate);
            ZoneId = item.ZoneId;
            Skills = item.Skills;
            Occupation = item.Occupation;
            VolunteerFor = item.VolunteerFor;
        }
    }

    public partial class Masjid
    {
        public Masjid(MasjidModel _obj)
        {
            Id = _obj.Id;
            Name = _obj.Name;
            Location = _obj.Location;
            HeadUserId = _obj.HeadUserId;
            ZoneId = _obj.ZoneId;
            Mobile = _obj.Mobile;
            CreatedDate = _obj.CreatedDate;
            CreatedBy = _obj.CreatedBy;
        }
    }

    public partial class MasjidExtensionRequest
    {
        public MasjidExtensionRequest()
        {

        }
        public MasjidExtensionRequest(MasjidExtensionRequestModel _obj)
        {
            Id = _obj.Id;
            ShortDescription = _obj.ShortDescription;
            UserId = _obj.UserId;
            Location = _obj.Location;
            Area = _obj.Area;
            MasjidId = _obj.MasjidId;
            ConstructionCost = _obj.ConstructionCost;
            ExistingFloors = _obj.ExistingFloors;
            AmountNeeded = _obj.AmountNeeded;
            Engineer = _obj.Engineer;
            Elevation = _obj.Elevation;
            Paln = _obj.Paln;
            Doc1 = _obj.Doc1;
            Doc2 = _obj.Doc2;
            Doc3 = _obj.Doc3;
            Pic1 = _obj.Pic1;
            Pic2 = _obj.Pic2;
            Pic3 = _obj.Pic3;
            RequestSubmitId = _obj.RequestSubmitId;
            Status = _obj.Status;
            CreatedDate = _obj.CreatedDate;
            RequestTypeId = _obj.RequestTypeId;
        }
    }

    public partial class MasjidLandRequest
    {
        public MasjidLandRequest()
        {

        }
        public MasjidLandRequest(MasjidLandRequestModel _obj)
        {

            Id = _obj.Id;
            ShortDescription = _obj.ShortDescription;
            UserId = _obj.UserId;
            Location = _obj.Location;
            Area = _obj.Area;
            MasjidId = _obj.MasjidId;
            TimePeriod = _obj.TimePeriod;
            AmountPaid = _obj.AmountPaid;
            AmountNeeded = _obj.AmountNeeded;
            LandArea = _obj.LandArea;
            LandPrice = _obj.LandPrice;
            PurchasingFrom = _obj.PurchasingFrom;
            Doc1 = _obj.Doc1;
            Doc2 = _obj.Doc2;
            Doc3 = _obj.Doc3;
            Pic1 = _obj.Pic1;
            Pic2 = _obj.Pic2;
            Pic3 = _obj.Pic3;
            RequestSubmitId = _obj.RequestSubmitId;
            Status = _obj.Status;
            CreatedDate = _obj.CreatedDate;
            RequestTypeId = _obj.RequestTypeId;
        }
    }

    public partial class MasjidRenovationRequest
    {
        public MasjidRenovationRequest()
        {

        }
        public MasjidRenovationRequest(MasjidRenovationRequestModel _obj)
        {

            Id = _obj.Id;
            ShortDescription = _obj.ShortDescription;
            UserId = _obj.UserId;
            Location = _obj.Location;
            Area = _obj.Area;
            MasjidId = _obj.MasjidId;
            ConstructionCost = _obj.ConstructionCost;
            ExistingFloors = _obj.ExistingFloors;
            AmountNeeded = _obj.AmountNeeded;
            Engineer = _obj.Engineer;
            Elevation = _obj.Elevation;
            Paln = _obj.Paln;
            Doc1 = _obj.Doc1;
            Doc2 = _obj.Doc2;
            Doc3 = _obj.Doc3;
            Pic1 = _obj.Pic1;
            Pic2 = _obj.Pic2;
            Pic3 = _obj.Pic3;
            RequestSubmitId = _obj.RequestSubmitId;
            Status = _obj.Status;
            CreatedDate = _obj.CreatedDate;
            RequestTypeId = _obj.RequestTypeId;
        }
    }
    public partial class MasjidConstructionRequest
    {
        public MasjidConstructionRequest()
        {

        }
        public MasjidConstructionRequest(MasjidConstructionRequestModel _obj)
        {
            Id = _obj.Id;
            ShortDescription = _obj.ShortDescription;
            UserId = _obj.UserId;
            Location = _obj.Location;
            Area = _obj.Area;
            MasjidId = _obj.MasjidId;
            ConstructionCost = _obj.ConstructionCost;
            ExistingFloors = _obj.ExistingFloors;
            AmountNeeded = _obj.AmountNeeded;
            Engineer = _obj.Engineer;
            Elevation = _obj.Elevation;
            Paln = _obj.Paln;
            Doc1 = _obj.Doc1;
            Doc2 = _obj.Doc2;
            Doc3 = _obj.Doc3;
            Pic1 = _obj.Pic1;
            Pic2 = _obj.Pic2;
            Pic3 = _obj.Pic3;
            RequestSubmitId = _obj.RequestSubmitId;
            Status = _obj.Status;
            CreatedDate = _obj.CreatedDate;
            RequestTypeId = _obj.RequestTypeId;
        }
    }

    public partial class NewMadarsaOperationsRequest
    {
        public NewMadarsaOperationsRequest()
        {

        }
        public NewMadarsaOperationsRequest(NewMadarsaOperationsRequestModel item)
        {

            Id = item.Id;
            ShortDescription = item.ShortDescription;
            Location = item.Location;
            Area = item.Area;
            ExpectedStudents = item.ExpectedStudents;
            Girls = item.Girls;
            Boys = item.Boys;
            Teachers = item.Teachers;
            IsResidential = item.IsResidential;
            MonthlyConst = item.MonthlyConst;
            CostPerStudent = item.CostPerStudent;
            RevenueSource = item.RevenueSource;
            TotalLandArea = item.TotalLandArea;
            ConstructedArea = item.ConstructedArea;
            IsRented = item.IsRented;
            ChargingStudent = item.ChargingStudent;
            IfChargingHowmuch = item.IfChargingHowmuch;

            Doc1 = item.Doc1;
            Doc2 = item.Doc2;
            Doc3 = item.Doc3;
            Pic1 = item.Pic1;
            Pic2 = item.Pic2;
            Pic3 = item.Pic3;
            Status = item.Status;
            CreatedDate = item.CreatedDate;
            // CreatedBy = item.CreatedBy;

            UserId = item.UserId;


            MadarsaId = item.MadarsaId;


            RequestTypeId = item.RequestTypeId;

            RequestSubmitId = item.RequestSubmitId;
        }
    }

    public partial class MadarsaLandRequest
    {
        public MadarsaLandRequest()
        {

        }
        public MadarsaLandRequest(MadarsaLandRequestModel _obj)
        {
            Id = _obj.Id;
            ShortDescription = _obj.ShortDescription;
            Location = _obj.Location;
            Area = _obj.Area;
            TimePeriod = _obj.TimePeriod;
            AmountPaid = _obj.AmountPaid;
            AmountNeeded = _obj.AmountNeeded;
            LandArea = _obj.LandArea;
            LandPrice = _obj.LandPrice;
            PurchasingFrom = _obj.PurchasingFrom;

            Doc1 = _obj.Doc1;
            Doc2 = _obj.Doc2;
            Doc3 = _obj.Doc3;
            Pic1 = _obj.Pic1;
            Pic2 = _obj.Pic2;
            Pic3 = _obj.Pic3;
            Status = _obj.Status;
            CreatedDate = _obj.CreatedDate;
            //  CreatedBy = _obj.CreatedBy;

            UserId = _obj.UserId;

            MadarsaId = _obj.MadarsaId;

            RequestTypeId = _obj.RequestTypeId;

            RequestSubmitId = _obj.RequestSubmitId;
            //  RequestSubmitId

        }
    }

    public partial class MadarsaExtensionRequest
    {
        public MadarsaExtensionRequest()
        {

        }
        public MadarsaExtensionRequest(MadarsaExtensionRequestModel item)
        {
            Id = item.Id;
            ShortDescription = item.ShortDescription;
            Location = item.Location;
            Area = item.Area;
            ConstructionCost = item.ConstructionCost;
            ExistingFloors = item.ExistingFloors;
            AmountNeeded = item.AmountNeeded;
            Engineer = item.Engineer;
            Elevation = item.Elevation;
            Paln = item.Paln;

            Doc1 = item.Doc1;
            Doc2 = item.Doc2;
            Doc3 = item.Doc3;
            Pic1 = item.Pic1;
            Pic2 = item.Pic2;
            Pic3 = item.Pic3;
            Status = item.Status;
            CreatedDate = item.CreatedDate;
            //CreatedBy = item.CreatedBy;

            UserId = item.UserId;

            MadarsaId = item.MadarsaId;

            RequestTypeId = item.RequestTypeId;

            RequestSubmitId = item.RequestSubmitId;
        }
    }

    public partial class ExistingMadarsaOperationsRequest
    {
        public ExistingMadarsaOperationsRequest()
        {

        }
        public ExistingMadarsaOperationsRequest(ExistingMadarsaOperationsRequestModel item)
        {

            Id = item.Id;
            ShortDescription = item.ShortDescription;
            Location = item.Location;
            Area = item.Area;
            ExpectedStudents = item.ExpectedStudents;
            IfChargingHowmuch = item.IfChargingHowmuch;
            Girls = item.Girls;
            Boys = item.Boys;
            Teachers = item.Teachers;
            IsResidential = item.IsResidential;
            MonthlyConst = item.MonthlyConst;
            CostPerStudent = item.CostPerStudent;
            RevenueSource = item.RevenueSource;
            TotalLandArea = item.TotalLandArea;
            ConstructedArea = item.ConstructedArea;
            IsRented = item.IsRented;
            ChargingStudent = item.ChargingStudent;
            Doc1 = item.Doc1;
            Doc2 = item.Doc2;
            Doc3 = item.Doc3;
            Pic1 = item.Pic1;
            Pic2 = item.Pic2;
            Pic3 = item.Pic3;
            Status = item.Status;
            CreatedDate = item.CreatedDate;
            //CreatedBy = item.CreatedBy;

            UserId = item.UserId;


            MadarsaId = item.MadarsaId;

            RequestTypeId = item.RequestTypeId;

            RequestSubmitId = item.RequestSubmitId;
        }

    }

    public partial class Madarsa

    {
        public Madarsa(MadarsaModel item)
        {
            Id = item.Id;
            Name = item.Name;
            Location = item.Location;
            Mobile = item.Mobile;
            HeadUserId = item.HeadUserId;
            ZoneId = item.ZoneId;
            CreatedDate = item.CreatedDate;
            CreatedBy = item.CreatedBy;
        }


    }
    public partial class RequestApprove

    {
        public RequestApprove()
        {

        }
        public RequestApprove(RequestApproveModel _obj)
        {
            Id = _obj.Id;
            UserId = _obj.UserId;
            RequestSubmitId = _obj.RequestSubmitId;
            IsApproved = _obj.IsApproved;

            UserTypeId = _obj.UserTypeId;
            CreatedDate = _obj.CreatedDate;
            IsLiked = _obj.LikeStatus;
        }


    }


    public partial class RequestComment
    {
        public RequestComment()
        {

        }
        public RequestComment(RequestCommentModel item)
        {
            Id = item.Id;
            UserId = item.UserId;
            RequestSubmitId = item.RequestSubmitId;
            Comment = item.Comment;
            UserTypeId = item.UserTypeId;
            CreatedDate = item.CreatedDate;
        }
    }


    public partial class RequestSubmit
    {
        public RequestSubmit(RequestSubmitModel item)
        {
            Id = item.Id;
            ShortDesc = item.ShortDesc;
            RequestTypeId = item.RequestTypeId;
            Comment = item.Comment;
            IsApproved = item.IsApproved;
            UserId = item.UserId;
            CreatedDate = item.CreatedDate;
        }
    }

    public partial class User
    {

        public User(UserModel item)
        {
            Id = item.Id;
            Name = item.Name;
            Email = item.Email;
            Contact = item.Contact;
            Area = item.Area;
            UserName = item.UserName;
            Password = item.Password;
            RoleId = item.RoleId;
            UserTypeId = item.UserTypeId;
            CreatedDate = item.CreatedDate;
            DeviceID = item.DeviceID;
            Platform = item.Platform;
            OTPPassword = item.OTPPassword;
            OTPGeneratedTime = item.OTPGeneratedTime;
            IsOTPCheck = item.IsOTPCheck;
        }
    }


    public partial class PanelInvolvement
    {
        public PanelInvolvement()
        {

        }
        public PanelInvolvement(PanelInvolvementModel item)
        {
            Id = item.Id;
            UserId = item.UserId;
            UserTypeId = item.UserTypeId;
            RequestSubmitId = item.RequestSubmitId;
            CreatedDate = Convert.ToDateTime(item.CreatedDate);
            IsObject = item.IsObject;
        }
    }


    public partial class Category
    {

        public Category(CategoryModel item)
        {
            Id = item.Id;
            Name = item.Name;
            IsDelete = item.IsDelete;
            CreatedDate = item.CreatedDate;
        }
    }


    public partial class UserCategoryMapping
    {

        public UserCategoryMapping(UserCategoryMappingModel item)
        {
            Id = item.Id;
            UserID = item.UserID;
            CategoryID = item.CategoryID;
            IsSelected = item.IsSelected;

        }
    }


    public partial class Course
    {

        public Course(CourseModel item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            IsDelete = item.IsDelete;
            Status = item.Status;
            CreatedOn = item.CreatedOn;
            CreatedBy = item.CreatedBy;
            UpdatedOn = item.UpdatedOn;
            UpdatedBy = item.UpdatedBy;

        }
    }
    public partial class Course_Test
    {

        public Course_Test(CourseTestModel item)
        {
            Id = item.Id;
            CourseID = item.CourseID;
            Question = item.Question;
            Answer1 = item.Answer1;
            Answer2 = item.Answer2;
            Answer3 = item.Answer3;
            Answer4 = item.Answer4;
            CorrectAnswer = item.CorrectAnswer;
            Mark = item.Mark;
            Reason = item.Reason;
            CreatedOn = item.CreatedOn;
            CreatedBy = item.CreatedBy;

        }
    }




    public partial class CourseSession
    {

        public CourseSession(CourseSessionModel item)
        {
            Id = item.Id;
            Topic = item.Topic;
            CourseID = item.CourseID;
            Document1 = item.Document1;
            Document2 = item.Document2;
            CreatedOn = item.CreatedOn;
            CreatedBy = item.CreatedBy;
            VideoLink = item.VideoLink;
            AudioLink = item.AudioLink;

        }
    }

    public partial class UserGroup
    {

        public UserGroup(UserGroupModel item)
        {
            Id = item.Id;
            Name = item.Name;
            IsActive = item.IsActive;
            CreatedOn = item.CreatedOn;
            CreatedBy = item.CreatedBy;
            UpdatedOn = item.UpdatedOn;
            UpdatedBy = item.UpdatedBy;

        }
    }

    public partial class UserGroup_Mapping
    {

        public UserGroup_Mapping(UserGroupModel item)
        {
            Id = item.Id;
            UserGroupID = item.UserGroupID;
            UserID = item.UserID;
            IsActive = item.IsActive;
            CreatedOn = item.CreatedOn;
        }
    }


    public partial class Course_Test_Answer
    {
        public Course_Test_Answer(CourseTestAnswerModel item)
        {
            Id = item.Id;
            CourseID = item.CourseID;
            CourseTestID = item.CourseTestID;
            Answer = item.Answer;
            UserID= item.UserID;
            IsCorrect= item.IsCorrect;
           CreatedOn = item.CreatedOn;
           
        }
    }
}

