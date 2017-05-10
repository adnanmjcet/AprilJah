using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;

namespace BusinessLayer.Interface
{
    public interface ICourseTest
    {
        List<CourseTestModel> CourseTestList();

        CourseTestModel GetCourseTest(CourseTestModel model);

        long Save(CourseTestModel model);

        CourseTestModel GetById(long id);

        List<CourseTestModel> GetCourseTestList(long courseId);
    }
}
