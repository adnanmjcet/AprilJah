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
    public class ExistingMadarsaOperationsRequestController : Controller
    {

        private ExistingMadarsaOperationsRequestModel _ExistingMadarsaModel;
        private readonly IExistingMadarsaOperationsRequest _ExistingMadarsaOperationsRequestModelBs;

        public ExistingMadarsaOperationsRequestController()
        {
            _ExistingMadarsaModel = new ExistingMadarsaOperationsRequestModel();
            _ExistingMadarsaOperationsRequestModelBs = new ExistingMadarsaOperationsRequestBs();
        }

        public ActionResult Index()
        {
            var varial = _ExistingMadarsaOperationsRequestModelBs.ExistingMadarsaOperationRequestList();
            return View(varial);
        }

        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                _ExistingMadarsaModel = _ExistingMadarsaOperationsRequestModelBs.GetById(Convert.ToInt32(id));
                _ExistingMadarsaModel.UserModelList = _ExistingMadarsaOperationsRequestModelBs.UserList().ToList();
                _ExistingMadarsaModel.RequestTypeModelList = _ExistingMadarsaOperationsRequestModelBs.RequestTypeList().ToList();
                _ExistingMadarsaModel.MadarsaModelList = _ExistingMadarsaOperationsRequestModelBs.MadarsaList().ToList();
                return View(_ExistingMadarsaModel);

            }
            else
            {
                _ExistingMadarsaModel.UserModelList = _ExistingMadarsaOperationsRequestModelBs.UserList().ToList();
                _ExistingMadarsaModel.RequestTypeModelList = _ExistingMadarsaOperationsRequestModelBs.RequestTypeList().ToList();
                _ExistingMadarsaModel.MadarsaModelList = _ExistingMadarsaOperationsRequestModelBs.MadarsaList().ToList();
                return View(_ExistingMadarsaModel);

            }



        }
        [HttpPost]
        public ActionResult Create(ExistingMadarsaOperationsRequestModel model, HttpPostedFileBase[] Files)
        {
            int result = 0;
            if (model != null)
            {
                UserRegistrationBs obj = new UserRegistrationBs();
                var id = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                model.RequestTypeId = 5;
                if (Files != null)
                {
                    model.Doc1 = new byte[Files[0].ContentLength];
                    Files[0].InputStream.Read(model.Doc1, 0, Files[0].ContentLength);
                }
                if (Files[1] != null)
                {
                    model.Doc2 = new byte[Files[1].ContentLength];
                    Files[1].InputStream.Read(model.Doc2, 0, Files[1].ContentLength);
                }

                if (Files[2] != null)
                {
                    model.Doc3 = new byte[Files[2].ContentLength];
                    Files[2].InputStream.Read(model.Doc3, 0, Files[2].ContentLength);
                }
                if (Files[3] != null)
                {
                    model.Pic1 = new byte[Files[3].ContentLength];
                    Files[3].InputStream.Read(model.Pic1, 0, Files[3].ContentLength);
                }
                if (Files[4] != null)
                {
                    model.Pic2 = new byte[Files[4].ContentLength];
                    Files[4].InputStream.Read(model.Pic2, 0, Files[4].ContentLength);
                }
                if (Files[5] != null)
                {
                    model.Pic3 = new byte[Files[5].ContentLength];
                    Files[5].InputStream.Read(model.Pic3, 0, Files[5].ContentLength);
                }

                model.UserId = id;
               result= _ExistingMadarsaOperationsRequestModelBs.Save(model);
            }
            if(result>0)
            {
                _ExistingMadarsaModel.UserModelList = _ExistingMadarsaOperationsRequestModelBs.UserList().ToList();
                _ExistingMadarsaModel.RequestTypeModelList = _ExistingMadarsaOperationsRequestModelBs.RequestTypeList().ToList();
                _ExistingMadarsaModel.MadarsaModelList = _ExistingMadarsaOperationsRequestModelBs.MadarsaList().ToList();
                TempData["message"] = "Request Submitted Successfully!";
            }
            return RedirectToAction("Index", "UserRequest", new { area = "User" });
        }

        public ActionResult Details(int id)
        {
            if (id != null && id != 0)
            {
                _ExistingMadarsaModel = _ExistingMadarsaOperationsRequestModelBs.GetById(id);
            }
            return View(_ExistingMadarsaModel);
        }
    }
}