using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class PostNotificationController : Controller
    {
        private readonly UserModel _userModel;
        private readonly UserRegistrationBs _userRegistrationBs;

        public PostNotificationController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
        }
        // GET: Admin/PostNotification
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string notificationMessage)
        {
            _userRegistrationBs.SendPushNotification(notificationMessage);
            return View();
        }
    }
}