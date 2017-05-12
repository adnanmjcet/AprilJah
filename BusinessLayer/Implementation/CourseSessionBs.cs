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
using FirebaseNet.Messaging;

namespace BusinessLayer.Implementation
{
    public class CourseSessionBs : ICourseSession
    {
        private readonly IGenericPattern<CourseSession> _CourseSession;
        private readonly IGenericPattern<Category> _category;
        private readonly IGenericPattern<UserCategoryMapping> _useCategoryrGroupMap;
        private readonly IGenericPattern<User> _user;

        public CourseSessionBs()
        {
            _CourseSession = new GenericPattern<CourseSession>();
            _category = new GenericPattern<Category>();
            _useCategoryrGroupMap = new GenericPattern<UserCategoryMapping>();
            _user = new GenericPattern<User>();
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
                AudioLink = x.AudioLink,
                VideoLink = x.VideoLink,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy

            }).ToList();
        }

        public List<CourseSessionModel> GetSessionByCourseID(long courseID)
        {
            return _CourseSession.GetWithInclude(x => x.CourseID == courseID).Select(x => new CourseSessionModel
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
            return _CourseSession.GetWithInclude(x => x.Id == id).Select(x => new CourseSessionModel
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

        public bool SendTopicNotification(Int64 topicID, Int64 courseID)
        {
            var topic = _CourseSession.GetWithInclude(x => x.Id == topicID).FirstOrDefault();
            var courseCategoryID = _category.GetWithInclude(x => x.Name == "Course").Select(x => x.Id).FirstOrDefault();
            var userIds = _useCategoryrGroupMap.GetWithInclude(x => x.CategoryID == courseCategoryID && x.IsSelected == true).Select(x => x.UserID).ToList();

            var deviceList = _user.GetWithInclude(x => userIds.Contains(x.Id) && x.DeviceID != null).Select(x => x.DeviceID).ToList();

            if (deviceList.Count == 0)
                return false;

            deviceList.ForEach(x =>
            {
                FCMClient client = new FCMClient("AAAAylgXv6E:APA91bHxCtlKnoU7NBp9P989-zIh8KS6oy6dG2ESyReH6DyaawXz9zfyogpiO6STy7-8ajMzlvpi1jAQ0VqOkKjSf8DtOk5vNbklD9q-F1V3rmAnR_oH-zYamaeTludLGqItoSjykVDe");
                var message = new Message()
                {
                    To = x,
                    Notification = new AndroidNotification()
                    {
                        Title = topic.Topic + " is avaliable.Current topicID is" + topic.Id,
                    }
                };
                var result = client.SendMessageAsync(message);
            });
            return true;
        }
    }
}
