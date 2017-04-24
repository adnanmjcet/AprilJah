using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    [Authorize(Roles = "Ameer")]
    public class AmeerApproveRequestController : Controller
    {
        private RequestSubmitModel _RequestSubmitModel;
        private readonly RequestSubmitBs _RequestSubmitBs;

        public AmeerApproveRequestController()
        {
            _RequestSubmitModel = new RequestSubmitModel();
            _RequestSubmitBs = new RequestSubmitBs();
        }  // GET: Admin/AmeerApproveRequest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApproveReject(RequestSubmitModel model)
        {

            if (model != null)
            {
                _RequestSubmitModel.Id = model.Id;
                _RequestSubmitModel.IsApproved = Convert.ToBoolean(true);
                _RequestSubmitBs.Save(_RequestSubmitModel);

            }
            return RedirectToAction("Index");

        }
        
        public ActionResult RejectRequest(RequestSubmitModel model)
        {
            if (model != null)
            {
                _RequestSubmitModel.Id = model.Id;
                _RequestSubmitModel.IsApproved = Convert.ToBoolean(false);
                _RequestSubmitBs.Save(_RequestSubmitModel);


            }
            return RedirectToAction("Index");

        }
    }
}