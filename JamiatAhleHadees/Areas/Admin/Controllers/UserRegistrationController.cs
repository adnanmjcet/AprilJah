using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class UserRegistrationController : Controller
    {
        private readonly UserModel _userModel;
        private readonly UserRegistrationBs _userRegistrationBs;
        public UserRegistrationController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
        }

        public ActionResult Index(int i)
        {

            var varial = _userRegistrationBs.UserRegistrationList();
            return View(varial);
        }

        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                var Varial = _userRegistrationBs.GetById(Convert.ToInt32(id));

                return View(Varial);

            }
            else
            {

                _userModel.UserLists = _userRegistrationBs.UserRegistrationList().ToList();

                return View(_userModel);

            }

        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            int i = 0;

            if (model != null)
            {
            i= _userRegistrationBs.Save(model);
            }

            if (i>0)
            {
                TempData["msg"] = "Registered Successfully";
            }
            else
            {
                TempData["msg"] = " Not Registered ";
            }
                
            return  RedirectToAction("Index", "Login", new { area = "User" });
         
        }
    }
}