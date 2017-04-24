using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.PanelMember.Controllers
{
    [Authorize(Roles = "Ameer,PanelMember")]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class PanelAgreeDisagreeController : Controller
    {
        private RequestApproveModel _RequestApproveModel;
        private RequestSubmitModel _RequestSubmitModel;
        private readonly RequestSubmitBs _RequestSubmitBs;
        private readonly MasjidConstructionRequestBs _MasjidConstructionRequestBs;
        private readonly RequestApproveRejectBs _RequestApproveBs;
        private readonly PanelInvolvementModel _PanelInvolvementModel;
        private readonly PanelInvolveBs _PanelInvolveBs;
        public PanelAgreeDisagreeController()
        {
            _RequestApproveModel = new RequestApproveModel();
            _RequestSubmitModel = new RequestSubmitModel();
            _RequestSubmitBs = new RequestSubmitBs();
            _MasjidConstructionRequestBs = new MasjidConstructionRequestBs();
            _RequestApproveBs = new RequestApproveRejectBs();
            _PanelInvolvementModel = new PanelInvolvementModel();
            _PanelInvolveBs = new PanelInvolveBs();
        }
        // GET: PanelMember/PanelAgreeDisagree ARExistingMadarsaOperation
        public ActionResult Index()
        {
            return View();
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked==true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;
                    
                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMadarsaLand(MadarsaLandRequestModel model)
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMasjidConstruction(MasjidConstructionRequestModel model)
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ARMasjidExtension(MasjidExtensionRequestModel model)
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
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
                _RequestApproveModel.LikeStatus = model.LikeStatus;
                if (model.AlreadyExistsInMemberOpinion && model.MemberOpinionId != 0)
                {
                    _RequestApproveModel.Id = model.MemberOpinionId;
                }

                if (model.IsObjectClicked == true)
                {
                    PanelInvolvementModel _PanelInvolvementModelObj = new PanelInvolvementModel(model, UserId, (Int32)UserTypeId);
                    _PanelInvolvementModelObj.IsObject = model.IsObject;

                    _PanelInvolveBs.Save(_PanelInvolvementModelObj);
                }
                else
                {
                    _RequestApproveBs.Save(_RequestApproveModel);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


    }
}