using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.PanelMember.Controllers
{
    [Authorize(Roles = "Ameer,PanelMember")]
    public class RequestLikeDisLikeController : Controller
    {
        private RequestLikeModel _RequestLikeModel;
        private readonly RequestLikeDisLikeBs _RequestLikeDisLikeBs;

        public RequestLikeDisLikeController()
        {
            _RequestLikeModel = new RequestLikeModel();
            _RequestLikeDisLikeBs = new RequestLikeDisLikeBs();
        }
        // GET: BoardMember/RequestApprove
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LikeDisLike(MasjidConstructionRequestModel model)
        {

            if (model != null)
            {
                _RequestLikeModel.UserId = Convert.ToInt32(model.UserId);
                _RequestLikeModel.RequestSubmitId = Convert.ToInt32(model.RequestSubmitId);
                _RequestLikeModel.IsLike = false;
                _RequestLikeModel.UserTypeId = 2;

                _RequestLikeDisLikeBs.Save(_RequestLikeModel);
            }
            return RedirectToAction("Index");

        }

        
    }
}