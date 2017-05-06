using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Implementation;
using CommonLayer.CommonModels;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseModel _courseModel;
        private readonly CourseBs _courseBs;
        private readonly CourseSessionModel _courseSessionModel;
        private readonly CourseSessionBs _courseSessionBs;


        public CourseController()
        {
            _courseModel = new CourseModel();
            _courseBs = new CourseBs();
            _courseSessionModel = new CourseSessionModel();
            _courseSessionBs = new CourseSessionBs();



        }
        // GET: Admin/Course
        public ActionResult Index()
        {
            var course = _courseBs.CourseList();
            return View(course);
            
        }

        public ActionResult Create(int? id)
        {
            CourseModel model = new CourseModel();
            if (id != null)
            {
                var Varial = _courseBs.GetById(Convert.ToInt32(id));

                return View(Varial);

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CourseModel model)
        {
            long i = 0;

            if (model != null)
            {
                i = _courseBs.Save(model);
            }

            if (i > 0)
            {
                TempData["msg"] = "Save Successfully";
            }
            else
            {
                TempData["msg"] = "Error while saving data";
            }

            return RedirectToAction("Index", "Course", new { area = "Admin" });

        }

        public ActionResult Delete(int? id)
        {
            var getCourse = _courseBs.GetById(id.Value);
            getCourse.IsDelete = true;
            _courseBs.Save(getCourse);
            return RedirectToAction("Index", "Course", new { area = "Admin" });
        }

        public ActionResult Sessions()
        {
            var courseSession = _courseSessionBs.CourseSessionList();
            return View(courseSession);
            
        }

        public ActionResult SessionCreate(int? id)
        {
            CourseSessionModel model = new CourseSessionModel();
            if (id != null)
            {
                var Varial = _courseSessionBs.GetById(Convert.ToInt32(id));

                return View(Varial);

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult SessionCreate(CourseSessionModel model)
        {
            long i = 0;

            if (model != null)
            {
                i = _courseSessionBs.Save(model);
            }

            if (i > 0)
            {
                TempData["msg"] = "Save Successfully";
            }
            else
            {
                TempData["msg"] = "Error while saving data";
            }

            return RedirectToAction("Sessions", "Course", new { area = "Admin" });

        }

        public ActionResult SessionDelete(int? id)
        {
            var getCourse = _courseBs.GetById(id.Value);
            getCourse.IsDelete = true;
            _courseBs.Save(getCourse);
            return RedirectToAction("Sessions", "Course", new { area = "Admin" });
        }
    }
}