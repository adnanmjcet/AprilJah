using System;
using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        private readonly CategoryModel _categoryModel;
        private readonly CategoryBs _categoryBs;

        public MasterController()
        {
            _categoryModel = new CategoryModel();
            _categoryBs = new CategoryBs();
        }

        // GET: Admin/Master
        public ActionResult Index()
        {
            var category = _categoryBs.CategoryList();
            return View(category);
        }

        public ActionResult Create(int? id)
        {
            CategoryModel model = new CategoryModel();
            if (id != null)
            {
                var Varial = _categoryBs.GetById(Convert.ToInt32(id));

                return View(Varial);

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            int i = 0;

            if (model != null)
            {
                i = _categoryBs.Save(model);
            }

            if (i > 0)
            {
                TempData["msg"] = "Save Successfully";
            }
            else
            {
                TempData["msg"] = "Error while saving data";
            }

            return RedirectToAction("Index", "Master", new { area = "Admin" });

        }

        public ActionResult Delete(int? id)
        {
            var getCategory = _categoryBs.GetById(id.Value);
            getCategory.IsDelete = true;
            _categoryBs.Save(getCategory);
            return RedirectToAction("Index", "Master", new { area = "Admin" });
        }
    }
}