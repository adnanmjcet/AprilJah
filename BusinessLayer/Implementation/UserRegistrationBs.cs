using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.GenericPattern.Implementation;
using FirebaseNet.Messaging;
using BusinessLayer.Extension;

namespace BusinessLayer.Implementation
{
    public class UserRegistrationBs : IUserRegistration
    {
        private readonly IGenericPattern<User> tbl_UserRegistration;
        private readonly IGenericPattern<UserGroup_Mapping> tbl_userGroupMap;
        private readonly IGenericPattern<Category> tbl_Category;
        private readonly IGenericPattern<UserCategoryMapping> tbl_UserCategoryMap;
        private readonly IGenericPattern<UserType> tbl_UserType;

        private readonly RequestSubmitModel _RequestSubmitModel;

        public UserRegistrationBs()
        {
            tbl_UserRegistration = new GenericPattern<User>();
            tbl_UserType = new GenericPattern<UserType>();
            tbl_Category = new GenericPattern<Category>();
            tbl_UserCategoryMap = new GenericPattern<UserCategoryMapping>();
            tbl_userGroupMap = new GenericPattern<UserGroup_Mapping>();
        }

        public List<UserModel> UserRegistrationList()
        {
            List<UserModel> _userModel = new List<UserModel>();
            var Vardata = tbl_UserRegistration.GetAll().ToList();
            _userModel = (from item in Vardata
                          select new UserModel
                          {
                              Id = item.Id,
                              Name = item.Name,
                              Contact = item.Contact,
                              Area = item.Area,
                              UserTypeId = item.UserTypeId,
                              Email = item.Email,
                              UserName = item.UserName,
                              Password = item.Password,
                              CreatedDate = item.CreatedDate,
                              MainUserType = item.UserType != null ? (Int32)item.UserType.MainUserType : 0
                          }).OrderByDescending(x => x.Id).ToList();
            return _userModel;
        }

        public List<UserModel> GetUserTypesByMainUserType(int mainUserType)
        {
            List<UserModel> _UserModelList = new List<UserModel>();
            var UserTypeList = tbl_UserType.FindBy(m => m.MainUserType == mainUserType);
            if (UserTypeList != null && UserTypeList.Any())
            {
                _UserModelList = (from @item in UserTypeList
                                  select new UserModel
                                  {
                                      UserTypeId = @item.Id
                                  }).ToList();
            }
            return _UserModelList;
        }

        //public List<UserModel> UserRegistrationList(string uname)
        //{
        //    List<UserModel> _userModel = new List<UserModel>();
        //    var Vardata = tbl_UserRegistration.GetAll().ToList();
        //    _userModel = (from item in Vardata
        //                  select new UserModel
        //                  {
        //                      Id = item.Id,
        //                      Name = item.Name,
        //                      Contact = item.Contact,
        //                      Area = item.Area,
        //                      Email = item.Email,
        //                      RoleId=item.RoleId,
        //                      UserTypeId=item.UserTypeId,
        //                      UserName=item.UserName,
        //                      Password = item.Password,
        //                      CreatedDate = item.CreatedDate,
        //                  }).OrderByDescending(x => x.Id).ToList();
        //    return _userModel;
        //}

        public UserModel GetById(int id)
        {
            UserModel _UserModel = new UserModel();
            var item = tbl_UserRegistration.GetWithInclude(x => x.Id == id).FirstOrDefault();


            _UserModel = new UserModel
            {
                Id = item.Id,
                Name = item.Name,
                Contact = item.Contact,
                Area = item.Area,
                Email = item.Email,
                UserName = item.UserName,
                Password = item.Password,
                CreatedDate = item.CreatedDate,
                DeviceID = item.DeviceID,
                Platform = item.Platform,
                OTPPassword = item.OTPPassword,
                OTPGeneratedTime = item.OTPGeneratedTime,
                IsOTPCheck = item.IsOTPCheck
            };
            return _UserModel;
        }
        public UserModel GetDetails(UserModel model)
        {
            model = model ?? new UserModel();
            if (model.Id != 0)
            {
                model.UserLists = UserRegistrationList();

            }
            model.UserLists = UserRegistrationList();

            return model;
        }

        public bool CheckUserName(string userName)
        {

            var user = tbl_UserRegistration.GetWithInclude(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
            if (user == null)
                return false;
            return true;
        }
        public int Save(UserModel model)
        {
            model.RoleId = 4;
            model.UserTypeId = 9;
            User _UserModel = new User(model);
            if (model.Id != null && model.Id != 0)
            {
                tbl_UserRegistration.Update(_UserModel);

            }
            else
            {
                // tbl_UserRegistration.CreatedDate = System.DateTime.Now;

                tbl_UserRegistration.Insert(_UserModel);
            }

            return _UserModel.Id;
        }

        public List<CategoryModel> CategoryList()
        {
            return tbl_Category.GetAll().Select(x => new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

        }
        public void SendPushNotification(PostNotificationModel model)
        {
            var userIds = new List<int>();
            if (model.UserType == 1)//if usertype is usergroup
            {
                if (model.UserGroupList.Count == 0)
                    return;

                userIds = tbl_userGroupMap.GetWithInclude(x => model.UserGroupList.Contains(x.UserGroupID.Value)).Select(x => x.UserID.Value).ToList();
            }
            else // else categoryId
                userIds = tbl_UserCategoryMap.GetWithInclude(x => x.CategoryID == model.CategoryID && x.IsSelected == true).Select(x => x.UserID).ToList();

            if (userIds.Count == 0)
                return;


            if (model.IsMobileNotification)
            {
                var deviceList = tbl_UserRegistration.GetWithInclude(x => userIds.Contains(x.Id) && x.DeviceID != null).Select(x => x.DeviceID).ToList();

                if (deviceList.Count > 0)
                {
                    deviceList.ForEach(x =>
                    {
                        FCMClient client = new FCMClient("AAAAylgXv6E:APA91bHxCtlKnoU7NBp9P989-zIh8KS6oy6dG2ESyReH6DyaawXz9zfyogpiO6STy7-8ajMzlvpi1jAQ0VqOkKjSf8DtOk5vNbklD9q-F1V3rmAnR_oH-zYamaeTludLGqItoSjykVDe");
                        var message = new Message()
                        {
                            To = x,
                            Notification = new AndroidNotification()
                            {
                                Title = model.Message,
                            }
                        };
                        var result = client.SendMessageAsync(message);
                    });
                }
            }
            if (model.IsSms)
            {
                string mobile = string.Empty;
                var mobileList = tbl_UserRegistration.GetWithInclude(x => userIds.Contains(x.Id) && x.Contact != null).Select(x => x.Contact).ToList();
                if (mobileList.Count == 0)
                    return;

                if (mobileList.Count > 0)
                {
                    mobileList.ForEach(x =>
                    {
                        mobile += x + ",";
                    });

                    mobile = mobile.Remove(mobile.Length - 1);
                    new SendSMS().Send(mobile, model.Message);
                }
            }

        }

        public bool UpdateUser(int userid, string deviceID, string platformID)
        {
            var userData = tbl_UserRegistration.GetWithInclude(x => x.Id == userid).FirstOrDefault();
            if (userData != null)
            {
                userData.DeviceID = deviceID;
                userData.Platform = !string.IsNullOrEmpty(platformID) ? Convert.ToInt32(platformID) : 0;
                tbl_UserRegistration.Update(userData);
                return true;
            }
            return false;
        }
    }
}
