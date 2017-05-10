using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly UserGroupModel _userGroupModel;
        private readonly UserGroupBS _userGroupBs;

        public UserGroupController()
        {
            _userGroupModel = new UserGroupModel();
            _userGroupBs = new UserGroupBS();
        }
        public ActionResult Index()
        {
            var userGroup = _userGroupBs.UserGroupList();
            return View(userGroup);
        }

        public ActionResult Create(int? id)
        {
            UserGroupModel model = new UserGroupModel();
            if (id != null)
            {
                var Varial = _userGroupBs.GetById(Convert.ToInt32(id));

                return View(Varial);

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserGroupModel model)
        {
            long i = 0;

            if (model != null)
            {
                i = _userGroupBs.Save(model);
            }

            if (i > 0)
            {
                TempData["msg"] = "Save Successfully";
            }
            else
            {
                TempData["msg"] = "Error while saving data";
            }

            return RedirectToAction("Index", "UserGroup", new { area = "Admin" });

        }

        public ActionResult UserList(Int64? userGroupID)
        {
            var userLIst = _userGroupBs.GetUserList(userGroupID.Value);
            userLIst.UserGroupID = userGroupID;
            return View(userLIst);
        }
        public ActionResult AddUser(UserGroupModel model, int[] UserCheckList)
        {

            model.UserCheckList = UserCheckList == null ? new List<int>() : UserCheckList.ToList();
            bool response = _userGroupBs.AddUserList(model);
            if (response)
            {
                TempData["msg"] = "Save Successfully";
            }
            else
            {
                TempData["msg"] = "Error while saving data";
            }
            return RedirectToAction("Index");
        }
    }
}