using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember.Controllers
{
    [Authorize(Roles = "BoardMember,Ameer")]
    public class RequestCommentController : Controller
    {
        private RequestCommentModel _RequestCommentModel;
        private readonly RequestCommentBs _RequestCommentBs;

        public RequestCommentController()
        {
            _RequestCommentModel = new RequestCommentModel();
            _RequestCommentBs = new RequestCommentBs();
        }
        // GET: BoardMember/RequestApprove
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CommentOnMasjidConstruction(MasjidConstructionRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnMasjidExtension(MasjidExtensionRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }
        public ActionResult CommentOnMadarsaExtension(MadarsaExtensionRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;

            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnMadarsaLand(MadarsaLandRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnMasjidLand(MasjidLandRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnMasjidRenovation(MasjidRenovationRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnNewMadarsaOperations(NewMadarsaOperationsRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;

            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnExistingMadarsaOperations(ExistingMadarsaOperationsRequestModel model)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            var UserId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var UserTypeId = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            if (model != null)
            {
                _RequestCommentModel.UserId = Convert.ToInt32(model.UserId);
                _RequestCommentModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestCommentModel.Comment = model.Comment;
                _RequestCommentModel.UserTypeId = Convert.ToInt32(UserTypeId);
                _RequestCommentBs.Save(_RequestCommentModel);
            }
            return Json("_RequestComentModel", JsonRequestBehavior.AllowGet);

        }
    }
}