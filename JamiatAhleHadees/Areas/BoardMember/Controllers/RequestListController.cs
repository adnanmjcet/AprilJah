using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using JamiatAhleHadees.Areas.User.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember.Controllers
{
    [Authorize(Roles = "BoardMember,Ameee")]
    public class RequestListController : Controller
    {

        private RequestSubmitModel _RequestSubmitModel;
        private readonly RequestSubmitBs _RequestSubmitBs;
        private readonly MasjidConstructionRequestBs _MasjidConstructionRequestBs;

        public RequestListController()
        {
            _RequestSubmitModel = new RequestSubmitModel();
            _RequestSubmitBs = new RequestSubmitBs();
            _MasjidConstructionRequestBs = new MasjidConstructionRequestBs();
        }
        // GET: BoardMember/RequestList
        public ActionResult Index()
        {
            var RequestList = _RequestSubmitBs.RequestSubmitList().ToList();
            return View(RequestList);
        }

        public ActionResult GetDetailsbyId(int Id, int RequestTypeId)
        {
            var ReturnResult = "";
            if (RequestTypeId == 1)
            {

                ReturnResult = "GetMasjidConstructionDetails";
            }

            else if (RequestTypeId == 2)
            {

                ReturnResult = "GetMasjidExtensionDetails";
            }


            else if (RequestTypeId == 3)
            {

                ReturnResult = "GetMasjidLandRequestDetails";
            }

            else if (RequestTypeId == 4)
            {

                ReturnResult = "GetMasjidRenovationRequestDetails";
            }

            else if (RequestTypeId == 5)
            {

                ReturnResult = "ExistingMadarasaOeprationDetails";
            }

            else if (RequestTypeId == 6)
            {

                ReturnResult = "MadarsaLandRequestDetails";
            }
            else if (RequestTypeId == 7)
            {

                ReturnResult = "NewMadarsaOperationRequestDetails";
            }
            else if (RequestTypeId == 8)
            {

                ReturnResult = "MadarsaExtensionRequestDetails";
            }



            return RedirectToAction(ReturnResult, new { id = Id });
        }

        public ActionResult GetMasjidConstructionDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MasjidConstructionRequestBs().GetByRequestId(Id);
            return View(res);
        }


        public ActionResult GetMasjidExtensionDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MasjidExtensionRequestBs().GetMasjidExtensionById(Id);
            return View(res);
        }


        public ActionResult GetMasjidLandRequestDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MasjidLandRequestBs().GetMasjidLandById(Id);
            return View(res);
        }


        public ActionResult GetMasjidRenovationRequestDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MasjidRenovationRequestBs().GetMasjidRenovationById(Id);
            return View(res);
        }


        public ActionResult MadarsaLandRequestDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MadarsaLandRequestBs().GetByRequestSubmitId(Id);
            return View(res);
        }

        public ActionResult NewMadarsaOperationRequestDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new NewMadarsaOperationsRequestBs().GetByRequestSubmitId(Id);
            return View(res);
        }

        public ActionResult MadarsaExtensionRequestDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new MadarsaExtensionRequestBs().GetByRequestSubmitId(Id, Convert.ToInt32(userId));
            return View(res);
        }

        public ActionResult ExistingMadarasaOeprationDetails(int Id)
        {
            var userId = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().UserTypeId;
            var res = new ExistingMadarsaOperationsRequestBs().GetByRequestSubmitId(Id);
            return View(res);


        }
    }
}