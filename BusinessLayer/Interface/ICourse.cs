using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLayer.CommonModels;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICourse
    {
        List<CourseModel> CourseList();

        CourseModel GetCourse(CourseModel model);

        long Save(CourseModel model);

        CourseModel GetById(int id);

        CourseModel GetCourseSessions(int id);



    }
}
