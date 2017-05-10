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
        private readonly UserGroupBS _userGroupBS;

        public PostNotificationController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
            _userGroupBS = new UserGroupBS();
        }
        // GET: Admin/PostNotification
        public ActionResult Index()
        {
            ViewBag.CategoryList = new SelectList(_userRegistrationBs.CategoryList(), "Id", "Name");
            ViewBag.UserGroupList = _userGroupBS.UserGroupList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(PostNotificationModel model)
        {
            _userRegistrationBs.SendPushNotification(model);
            ViewBag.CategoryList = new SelectList(_userRegistrationBs.CategoryList(), "Id", "Name");
            ViewBag.UserGroupList = _userGroupBS.UserGroupList();
            return View();
        }
    }
}