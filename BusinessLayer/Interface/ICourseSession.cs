using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;

namespace BusinessLayer.Interface
{
    public interface ICourseSession
    {
        List<CourseSessionModel> CourseSessionList();

        CourseSessionModel GetCourseSession(CourseSessionModel model);

        long Save(CourseSessionModel model);

        CourseSessionModel GetById(long id);

        List<CourseSessionModel> GetSessionByCourseID(long courseID);
    }
}
