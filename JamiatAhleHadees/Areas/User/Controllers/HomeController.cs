using BusinessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.User.Controllers
{
    [Authorize(Roles = "Ameer, User, BoardMember, PanelMember, Admin")]
    public class HomeController : Controller
    {

        private readonly RequestSubmitBs _RequestSubmitBs;
        private readonly UserRegistrationBs _UserRegistrationBs;
        public HomeController()
        {
            _RequestSubmitBs = new RequestSubmitBs();
            _UserRegistrationBs = new UserRegistrationBs();
        }
        // GET: User/Home
        public ActionResult Index()
        {
            TempData["pendingRequest"] = _RequestSubmitBs.RequestSubmitList().Where(m => m.IsApproved == null).Count();
            TempData["ApproveRequest"] = _RequestSubmitBs.RequestSubmitList().Where(m => m.IsApproved == true).Count();
            TempData["RejectedRequest"] = _RequestSubmitBs.RequestSubmitList().Where(m => m.IsApproved == false).Count();
            TempData["UserRegistrations"] = _UserRegistrationBs.UserRegistrationList().Count();
            return View();
        }
    }
}