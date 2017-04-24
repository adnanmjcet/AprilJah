using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.User.Controllers
{
    public class UserRequestController : Controller
    {
        private RequestSubmitModel _RequestSubmitModel;
        private readonly RequestSubmitBs _RequestSubmitBs;
      


        public UserRequestController()
        {

            _RequestSubmitModel = new RequestSubmitModel();
            _RequestSubmitBs = new RequestSubmitBs();
          
        }
        // GET: BoardMember/RequestList
        public ActionResult Index()
        {

            TempData["msg"] = TempData["message"];

            int userid = new UserRegistrationBs().UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            var RequestList = _RequestSubmitBs.RequestSubmitList().Where(x=>x.UserId==userid).ToList();
            return View(RequestList);
        }

    }
}