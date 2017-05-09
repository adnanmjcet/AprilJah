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
    public class CourseBs : ICourse
    {
        private readonly IGenericPattern<Course> _Course;

        public CourseBs()
        {
            _Course = new GenericPattern<Course>();
        }
        public List<CourseModel> CourseList()
        {
            return _Course.GetWithInclude(x => x.IsDelete == false).Select(x => new CourseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status,
                IsDelete = x.IsDelete,
                CreatedOn = x.CreatedOn,

            }).ToList();
        }

        public CourseModel GetById(int id)
        {
            return _Course.GetWithInclude(x => x.Id == id).Select(x => new CourseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status,
                IsDelete = x.IsDelete,
                CreatedOn = x.CreatedOn,
            }).FirstOrDefault();
        }

        public CourseModel GetCourseSessions(int id)
        {
            CourseModel _CourseSessionList = new CourseModel();

            var resdata = _Course.GetAll().Where(x => x.Id == id).ToList();
            _CourseSessionList = (from item in resdata
                                  select new CourseModel
                                  {
                                      Id = item.Id,
                                      Name = item.Name,
                                      Description = item.Description,
                                      Status = item.Status,
                                      IsDelete = item.IsDelete,
                                      CreatedOn = item.CreatedOn,
                                      CourseSessionList = new CourseSessionBs().CourseSessionList().Where(x => x.CourseID == id).ToList()

                                  }).FirstOrDefault();

            return _CourseSessionList;

        }

        public CourseModel GetCourse(CourseModel model)
        {
            throw new NotImplementedException();
        }

        public long Save(CourseModel model)
        {
            Course _tbl_course = new Course(model);
            if (model.Id != null && model.Id != 0)
            {
                _Course.Update(_tbl_course);

            }
            else
            {
                _tbl_course.IsDelete = false;
                _tbl_course.CreatedOn = System.DateTime.Now;
                _Course.Insert(_tbl_course);
            }

            return _tbl_course.Id;
        }
    }
}
