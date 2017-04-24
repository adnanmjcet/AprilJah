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
    public class PanelRequestCommentController : Controller
    {

        private RequestCommentModel _RequestCommentModel;
        private readonly RequestCommentBs _RequestCommentBs;

        public PanelRequestCommentController()
        {
            _RequestCommentModel = new RequestCommentModel();
            _RequestCommentBs = new RequestCommentBs();
        }
        // GET: BoardMember/RequestApprove
        public ActionResult Index()
        {
            return View();
        }




        public JsonResult CommentOnMardarsaLandRequest(MadarsaLandRequestModel model)
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

        public JsonResult CommentOnExsintingMardarsOperation(ExistingMadarsaOperationsRequestModel model)
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

        public JsonResult CommentOnMadarsaExtensionRequest(MadarsaExtensionRequestModel model)
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

        public JsonResult CommentOnNewMadarsaRequest(NewMadarsaOperationsRequestModel model)
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

        public JsonResult CommentOnMasjidRenovationRequest(MasjidRenovationRequestModel model)
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

        public JsonResult CommentOnMasjidExtensionRequest(MasjidExtensionRequestModel model)
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

        public JsonResult CommentOnMasjidLandRequest(MasjidLandRequestModel model)
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

        public JsonResult CommentOnMasjidConstruction(MasjidConstructionRequestModel model)
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
    }
}
               