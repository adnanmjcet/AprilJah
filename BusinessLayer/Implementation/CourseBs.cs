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
    public class CourseBs : ICourse
    {
        private readonly IGenericPattern<Course> _Course;
        private readonly IGenericPattern<Course_Test_Answer> _courseTestAnswer;
        private readonly IGenericPattern<Category> _category;
        private readonly IGenericPattern<UserCategoryMapping> _useCategoryrGroupMap;
        private readonly IGenericPattern<User> _user;

        public CourseBs()
        {
            _Course = new GenericPattern<Course>();
            _category = new GenericPattern<Category>();
            _useCategoryrGroupMap = new GenericPattern<UserCategoryMapping>();
            _courseTestAnswer = new GenericPattern<Course_Test_Answer>();
            _user = new GenericPattern<User>();
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

        public Int64 GetActiveCourse()
        {
            return _Course.GetWithInclude(x => x.Status == true).Select(x => x.Id).FirstOrDefault();
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

            var resdata = _Course.GetWithInclude(x => x.Id == id).ToList();
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

            _CourseSessionList.CourseSessionAnswer = GetCouseSessionByCourseID(id);
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

        public bool EnableTest(int? courseID, bool isStart = false)
        {
            var getactive = _Course.GetWithInclude(x => x.Status == true || x.Status == null).FirstOrDefault();
            if (getactive != null)
            {
                getactive.Status = false;
                getactive.UpdatedOn = DateTime.Now;
                _Course.Update(getactive);
            }

            var toactive = _Course.GetWithInclude(x => x.Id == courseID).FirstOrDefault();
            toactive.Status = isStart;
            toactive.UpdatedOn = DateTime.Now;
            _Course.Update(toactive);

            if (!isStart)
                return true;

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
                        Title = toactive.Name + " test is avaliable.",
                    }
                };
                var result = client.SendMessageAsync(message);
            });
            return true;
        }

        public List<CourseTestAnswerModel> GetCouseSessionByCourseID(Int64 courseID)
        {

            return _courseTestAnswer.GetWithInclude(x => x.CourseID == courseID).Select(x => new CourseTestAnswerModel
            {
                UserName = x.User.Name,
                CreatedOn = x.CreatedOn,
                Score = 80
            }).ToList();

        }


    }
}
