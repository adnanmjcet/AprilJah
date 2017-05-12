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
    public class CourseTestBs : ICourseTest
    {
        private readonly IGenericPattern<Course_Test> _CourseTest;

        public CourseTestBs()
        {
            _CourseTest = new GenericPattern<Course_Test>();
        }
        public List<CourseTestModel> CourseTestList()
        {
            return _CourseTest.GetAll().Select(x => new CourseTestModel
            {
                Id = x.Id,
                Question = x.Question,
                CourseID=x.CourseID,
                Answer1 = x.Answer1,
                Answer2 = x.Answer2,
                Answer3 = x.Answer3,
                Answer4 = x.Answer4,
                CorrectAnswer = x.CorrectAnswer,
                Mark = x.Mark,
                Reason = x.Reason,
                CreatedOn = x.CreatedOn,

            }).ToList();
        }

        public CourseTestModel GetCourseTest(CourseTestModel model)
        {
            throw new NotImplementedException();
        }

        public long Save(CourseTestModel model)
        {
            Course_Test _tbl_course = new Course_Test(model);
            if (model.Id != null && model.Id != 0)
            {
                _CourseTest.Update(_tbl_course);

            }
            else
            {

                _CourseTest.Insert(_tbl_course);
            }

            return _tbl_course.Id;
        }

        public CourseTestModel GetById(long id)
        {
            return _CourseTest.GetWithInclude(x => x.Id == id).Select(x => new CourseTestModel
            {
                Id = x.Id,
                CourseID=x.CourseID,
                Question = x.Question,
                Answer1 = x.Answer1,
                Answer2 = x.Answer2,
                Answer3 = x.Answer3,
                Answer4 = x.Answer4,
                CorrectAnswer = x.CorrectAnswer,
                Mark = x.Mark,
                Reason = x.Reason,
                CreatedOn = x.CreatedOn,

            }).FirstOrDefault();
        }

        public List<CourseTestModel> GetCourseTestList(long courseId)
        {
            return _CourseTest.GetWithInclude(x=>x.CourseID== courseId).Select(x => new CourseTestModel
            {
                Id = x.Id,
                Question = x.Question,
                CourseID = x.CourseID,
                Answer1 = x.Answer1,
                Answer2 = x.Answer2,
                Answer3 = x.Answer3,
                Answer4 = x.Answer4,
                CorrectAnswer = x.CorrectAnswer,
                Mark = x.Mark,
                Reason = x.Reason,
                CreatedOn = x.CreatedOn,

            }).ToList();
        }

    }
}
