using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;

namespace BusinessLayer.Implementation
{
    public class CourseTestAnswerBs : ICourseTestAnswer
    {
        private readonly IGenericPattern<Course_Test_Answer> _CourseTestAnswer;
        private readonly IGenericPattern<Course_Test> _CourseTest;
        public CourseTestAnswerBs()
        {
            _CourseTestAnswer = new GenericPattern<Course_Test_Answer>();
            _CourseTest = new GenericPattern<Course_Test>();

        }
        public List<CourseTestAnswerModel> CourseTestAnswerList()
        {
            return _CourseTestAnswer.GetAll().Select(x => new CourseTestAnswerModel
            {
                Id = x.Id,
                CourseTestID = x.CourseTestID,
                CourseID = x.CourseID,
                Answer = x.Answer,
                UserID = x.UserID,
                IsCorrect = x.IsCorrect,
                CreatedOn = x.CreatedOn,

            }).ToList();
        }

        public CourseTestAnswerModel GetById(long id)
        {
            return _CourseTestAnswer.GetWithInclude(x => x.Id == id).Select(x => new CourseTestAnswerModel
            {
                Id = x.Id,
                CourseTestID = x.CourseTestID,
                CourseID = x.CourseID,
                Answer = x.Answer,
                UserID = x.UserID,
                IsCorrect = x.IsCorrect,
                CreatedOn = x.CreatedOn,

            }).FirstOrDefault();
        }

        public CourseTestAnswerModel GetCourseTestAnswer(CourseTestAnswerModel model)
        {
            throw new NotImplementedException();
        }

        public List<CourseTestAnswerModel> GetCourseTestAnswerList(long courseId)
        {
            throw new NotImplementedException();
        }

        public long Save(CourseTestAnswerModel model)
        {
            Course_Test_Answer _tbl_courseTest = new Course_Test_Answer(model);
            if (model.Id != null && model.Id != 0)
            {
                _CourseTestAnswer.Update(_tbl_courseTest);

            }
            else
            {

                _CourseTestAnswer.Insert(_tbl_courseTest);
            }

            return _tbl_courseTest.Id;
        }


        public void UpdateCourseTestAnswer(List<CourseTestAnswerModel> lstmodel)
        {
            var courseTestIds = lstmodel.Select(x => x.CourseTestID).ToList();
            var courseTestList = _CourseTest.GetWithInclude(z => courseTestIds.Contains(z.Id)).ToList();
            if (courseTestList.Count == 0)
                return;

            lstmodel.ForEach(x =>
            {
                var courseTest = courseTestList.Where(z => z.Id == x.CourseTestID).FirstOrDefault();
                if (courseTest != null)
                {
                    Course_Test_Answer model = new Course_Test_Answer();
                    model.CourseID = courseTest.CourseID;
                    model.CourseTestID = x.CourseTestID;
                    model.Answer = x.Answer;
                    model.UserID = x.UserID;
                    model.IsCorrect = courseTest.CorrectAnswer == x.Answer ? true : false;
                    model.CreatedOn = DateTime.Now;
                    _CourseTestAnswer.Insert(model);
                }

            });
        }
    }
}
