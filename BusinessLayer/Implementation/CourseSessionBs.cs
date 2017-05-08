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
    public class CourseSessionBs : ICourseSession
    {
        private readonly IGenericPattern<CourseSession> _CourseSession;

        public CourseSessionBs()
        {
            _CourseSession = new GenericPattern<CourseSession>();
        }
        public List<CourseSessionModel> CourseSessionList()
        {
            return _CourseSession.GetAll().Select(x => new CourseSessionModel
            {
                Id = x.Id,
                Topic = x.Topic,
                CourseID = x.CourseID,
                Document1 = x.Document1,
                Document2 = x.Document2,
                AudioLink=x.AudioLink,
                VideoLink=x.VideoLink,
                CreatedOn = x.CreatedOn,
                CreatedBy=x.CreatedBy

            }).ToList();
        }

        public List<CourseSessionModel> GetSessionByCourseID(long courseID)
        {
            return _CourseSession.GetWithInclude(x=>x.CourseID==courseID).Select(x => new CourseSessionModel
            {
                Id = x.Id,
                Topic = x.Topic,
                CourseID = x.CourseID,
                Document1 = x.Document1,
                Document2 = x.Document2,
                AudioLink = x.AudioLink,
                VideoLink = x.VideoLink,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy

            }).ToList();
        }

        public CourseSessionModel GetById(long id)
        {
            return _CourseSession.GetWithInclude(x=>x.Id==id).Select(x => new CourseSessionModel
            {
                Id = x.Id,
                Topic = x.Topic,
                CourseID = x.CourseID,
                Document1 = x.Document1,
                Document2 = x.Document2,
                AudioLink = x.AudioLink,
                VideoLink = x.VideoLink,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy

            }).FirstOrDefault();
        }

        public CourseSessionModel GetCourseSession(CourseSessionModel model)
        {
            throw new NotImplementedException();
        }

        public long Save(CourseSessionModel model)
        {
            CourseSession _tbl_courseSession = new CourseSession(model);
            if (model.Id != null && model.Id != 0)
            {
                _CourseSession.Update(_tbl_courseSession);

            }
            else
            {
                
                _tbl_courseSession.CreatedOn = System.DateTime.Now;
                _CourseSession.Insert(_tbl_courseSession);
            }

            return _tbl_courseSession.Id;
        }
    }
}
