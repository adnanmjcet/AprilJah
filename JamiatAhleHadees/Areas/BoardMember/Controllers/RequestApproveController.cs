using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember.Controllers
{
    [Authorize(Roles = "BoardMember")]
    public class RequestApproveController : Controller
    {
        private RequestApproveModel _RequestApproveModel;
        private readonly RequestApproveRejectBs _RequestApproveBs;

        public RequestApproveController()
        {
            _RequestApproveModel = new RequestApproveModel();
            _RequestApproveBs = new RequestApproveRejectBs();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApproveMasjidConstruction(MasjidConstructionRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ARMasjidExten(MasjidExtensionRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMasjidRenovation(MasjidRenovationRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMasjidLand(MasjidLandRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARNewMadarsaOperation(NewMadarsaOperationsRequestModel model)

        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMadarsaland(MadarsaLandRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMadarsaExtension(MadarsaExtensionRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);                
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId!=0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true,JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARExistingMadarsaOperation(ExistingMadarsaOperationsRequestModel model)
        {
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
                _RequestApproveModel.UserId = Convert.ToInt32(UserId);
                _RequestApproveModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestApproveModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestApproveModel.IsApproved = model.Status ?? false;

                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }
                _RequestApproveBs.Save(_RequestApproveModel);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

}