using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.User.Controllers
{
    [Authorize(Roles = "Ameer,User")]
    public class MasjidExtensionRequestController : Controller
    {
        // GET: User/MasjidExtensionRequest
        private MasjidExtensionRequestModel _MERModel;
        private readonly IMasjidExtensionRequest _MERBs;
        public MasjidExtensionRequestController()
        {
            _MERModel = new MasjidExtensionRequestModel();
            _MERBs = new MasjidExtensionRequestBs();
        }


        public ActionResult Index()
        {
            var res = _MERBs.MasjidExtensionRequestList();
            return View(res);
        }


        public ActionResult Create(int? id)

        {
            if (id != null)
            {
                _MERModel = _MERBs.GetById(Convert.ToInt32(id));
                _MERModel.UserLists = _MERBs.UserList().ToList();
                _MERModel.MasjidLists = _MERBs.MasjidList().ToList();
                _MERModel.RequestTypeLists = _MERBs.RequestTypeList().ToList();
            }
            else
            {
                _MERModel.MasjidLists = _MERBs.MasjidList().ToList();
                _MERModel.UserLists = _MERBs.UserList().ToList();
                _MERModel.RequestTypeLists = _MERBs.RequestTypeList().ToList();
            }

            return View(_MERModel);
        }
        [HttpPost]
        public ActionResult Create(MasjidExtensionRequestModel model, HttpPostedFileBase[] Files)
        {
            int result = 0;
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var id = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                model.RequestTypeId = 2;
                if (Files != null)
                {
                    model.Paln = new byte[Files[0].ContentLength];
                    Files[0].InputStream.Read(model.Paln, 0, Files[0].ContentLength);
                }
                if (Files[1] != null)
                {
                    model.Elevation = new byte[Files[1].ContentLength];
                    Files[1].InputStream.Read(model.Elevation, 0, Files[1].ContentLength);
                }

                if (Files[2] != null)
                {
                    model.Doc1 = new byte[Files[2].ContentLength];
                    Files[2].InputStream.Read(model.Doc1, 0, Files[2].ContentLength);
                }
                if (Files[3] != null)
                {
                    model.Doc2 = new byte[Files[3].ContentLength];
                    Files[3].InputStream.Read(model.Doc2, 0, Files[3].ContentLength);
                }
                if (Files[4] != null)
                {
                    model.Doc3 = new byte[Files[4].ContentLength];
                    Files[4].InputStream.Read(model.Doc3, 0, Files[4].ContentLength);
                }
                if (Files[5] != null)
                {
                    model.Pic1 = new byte[Files[5].ContentLength];
                    Files[5].InputStream.Read(model.Pic1, 0, Files[5].ContentLength);
                }

                if (Files[6] != null)
                {
                    model.Pic2 = new byte[Files[6].ContentLength];
                    Files[6].InputStream.Read(model.Pic2, 0, Files[6].ContentLength);
                }
                if (Files[7] != null)
                {
                    model.Pic3 = new byte[Files[7].ContentLength];
                    Files[7].InputStream.Read(model.Pic3, 0, Files[7].ContentLength);
                }

                model.UserId = id;
                result = _MERBs.Save(model);
            }
            if (result > 0)
            {
                _MERModel.MasjidLists = _MERBs.MasjidList().ToList();
                _MERModel.UserLists = _MERBs.UserList().ToList();
                _MERModel.RequestTypeLists = _MERBs.RequestTypeList().ToList();

                TempData["message"] = "Request Submitted Successfully";
            }
            return RedirectToAction("Index", "UserRequest", new { area = "User" });
        }
    }
}