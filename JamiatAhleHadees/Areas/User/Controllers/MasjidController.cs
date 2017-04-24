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
    public class MasjidController : Controller
    {
        // GET: User/Masjid
        private MasjidModel _MasjidModel;
        private readonly IMasjid _MasjidBs;
        public MasjidController()
        {
            _MasjidModel = new MasjidModel();
            _MasjidBs = new MasjidBs();
        }
        // GET: Admin/AddMasjid
        public ActionResult Index()
        {
            var res = _MasjidBs.MasjidList();
            return View(res);
        }


        public ActionResult Create(int? id)

        {
            if (id != null)
            {
                _MasjidModel = _MasjidBs.GetById(Convert.ToInt32(id));
                _MasjidModel.UserLists = _MasjidBs.UserList().ToList();
                _MasjidModel.ZoneLists = _MasjidBs.ZoneList().ToList();

            }
            else
            {
                _MasjidModel.MasjidLists = _MasjidBs.MasjidList().ToList();
                _MasjidModel.UserLists = _MasjidBs.UserList().ToList();
                _MasjidModel.ZoneLists = _MasjidBs.ZoneList().ToList();
            }

            return View(_MasjidModel);
        }


        [HttpPost]
        public ActionResult Create(MasjidModel model)
        {
            if (model != null)
            {
                _MasjidBs.Save(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RequestForApproval(int id)
        {
            var res = new MasjidConstructionRequestBs().GetById(id);
            return View(res);
        }

    }
}