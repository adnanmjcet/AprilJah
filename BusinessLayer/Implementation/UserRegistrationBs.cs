﻿using BusinessLayer.Interface;
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

namespace BusinessLayer.Implementation
{
    public class UserRegistrationBs : IUserRegistration
    {
        private readonly IGenericPattern<User> tbl_UserRegistration;
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
            var item = tbl_UserRegistration.GetById(id);


            _UserModel = new UserModel
            {
                Id = item.Id,
                Name = item.Name,
                Contact = item.Contact,
                Area = item.Area,
                Email = item.Email,
                //Name = item.UserName,
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
        public void SendPushNotification(string notiMessage, int? categoryID)
        {
            var userIDs = tbl_UserCategoryMap.GetWithInclude(x => x.CategoryID == categoryID && x.IsSelected == true).Select(x => x.UserID).ToList();

            if (userIDs.Count == 0)
                return;

            var deviceList = tbl_UserRegistration.GetWithInclude(x => userIDs.Contains(x.Id) && x.DeviceID != null).Select(x => x.DeviceID).ToList();

            if (deviceList.Count == 0)
                return;

            deviceList.ForEach(x =>
            {
                FCMClient client = new FCMClient("AAAAylgXv6E:APA91bHxCtlKnoU7NBp9P989-zIh8KS6oy6dG2ESyReH6DyaawXz9zfyogpiO6STy7-8ajMzlvpi1jAQ0VqOkKjSf8DtOk5vNbklD9q-F1V3rmAnR_oH-zYamaeTludLGqItoSjykVDe");
                var message = new Message()
                {
                    To = x,
                    Notification = new AndroidNotification()
                    {
                        Title = notiMessage,
                    }
                };
                var result = client.SendMessageAsync(message);
            });
        }

    }
}
