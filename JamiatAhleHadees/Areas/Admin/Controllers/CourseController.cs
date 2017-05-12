using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System.IO;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseModel _courseModel;
        private readonly CourseBs _courseBs;
        private readonly CourseSessionModel _courseSessionModel;
        private readonly CourseSessionBs _courseSessionBs;
        private readonly CourseTestModel _courseTestModel;
        private readonly CourseTestBs _courseTestBs;

        public CourseController()
        {
            _courseModel = new CourseModel();
            _courseBs = new CourseBs();
            _courseSessionModel = new CourseSessionModel();
            _courseSessionBs = new CourseSessionBs();
            _courseTestBs = new CourseTestBs();
            _courseTestModel = new CourseTestModel();
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

        public ActionResult Sessions(long? id)
        {
            var courseSession = _courseSessionBs.GetSessionByCourseID(id.Value);
            TempData["CourseID"] = id.Value;
            return View(courseSession);

        }

        public ActionResult SessionCreate(long? id)
        {
            if (id != null)
            {
                var Varial = _courseSessionBs.GetById(Convert.ToInt32(id));
                return View(Varial);

            }
            CourseSessionModel model = new CourseSessionModel();
            if (TempData["CourseID"] != null)
                model.CourseID = Convert.ToInt64(TempData["CourseID"]);

            return View(model);
        }
        [HttpPost]
        public ActionResult SessionCreate(FormCollection form, HttpPostedFileBase FirstDocument, HttpPostedFileBase SecondDocument)
        {

            List<CourseSessionModel> model = new List<CourseSessionModel>();

            var keys = form.AllKeys.Where(x => x.StartsWith("Topic")).ToList();

            var obj = new CourseSessionModel();
            foreach (var item in keys)
            {
                var currentKeyNum = item.Replace("Topic", "");
                obj.Id = Convert.ToInt64(form["Id"]);
                obj.CourseID = Convert.ToInt64(form["CourseID"]);
                obj.Topic = form["Topic" + currentKeyNum];
                obj.AudioLink = form["AudioLink" + currentKeyNum];
                obj.VideoLink = form["VideoLink" + currentKeyNum];

                if (FirstDocument == null ? false : FirstDocument.ContentLength > 0)
                {

                    var ext = Path.GetExtension(FirstDocument.FileName);
                    Random number = new Random();
                    obj.Document1 = "Document_" + number.Next(1000000000) + ext;
                    string path = Server.MapPath("~/Documents/" + obj.Document1);
                    FirstDocument.SaveAs(path);
                    // save image
                }
                if (SecondDocument == null ? false : SecondDocument.ContentLength > 0)
                {

                    var ext = Path.GetExtension(SecondDocument.FileName);
                    Random number = new Random();
                    obj.Document2 = "Document_" + number.Next(1000000000) + ext;
                    string path = Server.MapPath("~/Documents/" + obj.Document2);
                    SecondDocument.SaveAs(path);
                    // save image
                }

                //obj.Document1 = form["FirstDocument" + currentKeyNum];
                // obj.Document2 = form["SecondDocument" + currentKeyNum];

                _courseSessionBs.Save(obj);
            }


            //long i = 0;

            //if (model != null)
            //{
            //    i = _courseSessionBs.Save(model);
            //}

            //if (i > 0)
            //{
            //    TempData["msg"] = "Save Successfully";
            //}
            //else
            //{
            //    TempData["msg"] = "Error while saving data";
            //}

            return RedirectToAction("Sessions", "Course", new { area = "Admin", id = obj.CourseID });

        }

        public ActionResult SessionDelete(int? id)
        {
            var getCourse = _courseBs.GetById(id.Value);
            getCourse.IsDelete = true;
            _courseBs.Save(getCourse);
            return RedirectToAction("Sessions", "Course", new { area = "Admin" });
        }

        public ActionResult ViewCourse(int? id)
        {
            var res = _courseBs.GetCourseSessions(id.Value);

            return View(res);
        }

        public ActionResult StartTest(int? courseID, bool isStart = false)
        {
            var response = _courseBs.EnableTest(courseID, isStart);
            return RedirectToAction("Index");
        }
        public ActionResult CourseTest(long? id)
        {
            var courseTestSession = _courseTestBs.GetCourseTestList(id.Value);
            TempData["CourseID"] = id.Value;

            return View(courseTestSession);
        }


        public ActionResult CourseTestCreate(long? id)
        {
            if (id != null)
            {
                var Varial = _courseTestBs.GetById(id.Value);
                return View(Varial);

            }
            CourseTestModel model = new CourseTestModel();
            if (TempData["CourseID"] != null)
                model.CourseID = Convert.ToInt64(TempData["CourseID"]);

            return View(model);
        }
        [HttpPost]
        public ActionResult CourseTestCreate(FormCollection form)
        {

            List<CourseTestModel> model = new List<CourseTestModel>();

            var keys = form.AllKeys.Where(x => x.StartsWith("Question")).ToList();

            var obj = new CourseTestModel();
            foreach (var item in keys)
            {
                var currentKeyNum = item.Replace("Question", "");
                obj.Id = Convert.ToInt64(form["Id"]);
                obj.CourseID = Convert.ToInt64(form["CourseID"]);
                obj.Question = form["Question" + currentKeyNum];
                obj.Answer1 = form["Answer1" + currentKeyNum];
                obj.Answer2 = form["Answer2" + currentKeyNum];
                obj.Answer3 = form["Answer3" + currentKeyNum];
                obj.Answer4 = form["Answer4" + currentKeyNum];
                obj.CorrectAnswer = form["CorrectAnswer" + currentKeyNum];
                obj.Mark = form["Mark" + currentKeyNum];
                obj.Reason = form["Reason" + currentKeyNum];

                _courseTestBs.Save(obj);
            }


            //long i = 0;

            //if (model != null)
            //{
            //    i = _courseSessionBs.Save(model);
            //}

            //if (i > 0)
            //{
            //    TempData["msg"] = "Save Successfully";
            //}
            //else
            //{
            //    TempData["msg"] = "Error while saving data";
            //}

            return RedirectToAction("CourseTest", "Course", new { area = "Admin", id = obj.CourseID });

        }

        public ActionResult CourseTestDelete(int? id)
        {
            var getCourse = _courseBs.GetById(id.Value);
            getCourse.IsDelete = true;
            _courseBs.Save(getCourse);
            return RedirectToAction("Sessions", "Course", new { area = "Admin" });
        }


        public ActionResult ViewResult(int? id)
        {
            var res = _courseBs.GetCourseSessions(id.Value);

            return View(res);
        }

        public ActionResult SendTopicNotification(Int64? topicID, Int64? courseID)
        {
            var response = _courseSessionBs.SendTopicNotification(topicID.Value, courseID.Value);
            return RedirectToAction("ViewCourse", new { id = courseID });
        }

    }
}