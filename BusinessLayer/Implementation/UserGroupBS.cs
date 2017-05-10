using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLayer.Implementation
{
    public class UserGroupBS : IUserGroupBS
    {
        private readonly IGenericPattern<UserGroup> _userGroup;
        private readonly IGenericPattern<User> _user;
        private readonly IGenericPattern<UserGroup_Mapping> _userGroupMap;

        public UserGroupBS()
        {
            _userGroup = new GenericPattern<UserGroup>();
            _user = new GenericPattern<User>();
            _userGroupMap = new GenericPattern<UserGroup_Mapping>();
        }

        public List<UserGroupModel> UserGroupList()
        {
            return _userGroup.GetWithInclude(x => x.IsActive == true).Select(x => new UserGroupModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn,
                UserCount = x.UserGroup_Mapping.Count(),
            }).OrderByDescending(x => x.Id).ToList();
        }

        public UserGroupModel GetById(int id)
        {
            return _userGroup.GetWithInclude(x => x.Id == id).Select(x => new UserGroupModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn,
            }).FirstOrDefault();
        }

        public long Save(UserGroupModel model)
        {
            UserGroup _tbl_userGroup = new UserGroup(model);
            if (model.Id != null && model.Id != 0)
            {
                _tbl_userGroup.UpdatedOn = System.DateTime.Now;
                _tbl_userGroup.IsActive = true;
                _userGroup.Update(_tbl_userGroup);

            }
            else
            {
                _tbl_userGroup.IsActive = true;
                _tbl_userGroup.CreatedOn = System.DateTime.Now;
                _userGroup.Insert(_tbl_userGroup);
            }

            return _tbl_userGroup.Id;
        }

        public UserGroupModel GetUserList(Int64 userGroupID)
        {
            UserGroupModel model = new UserGroupModel();
            var userList = _user.GetAll().Select(x => new UserGroupModel
            {
                UserID = x.Id,
                Name = x.Name,
                UserTypeName = x.UserType.Name,
                IsSelected = false
            }).ToList();
            var userIds = userList.Select(x => x.UserID).ToList();
            var userMapping = _userGroupMap.GetWithInclude(x => userIds.Contains(x.UserID.Value) && x.UserGroupID == userGroupID && x.IsActive == true).ToList();
            if (userMapping.Count == 0)
            {
                model.UserList = userList;
                return model;
            }

            userList.ForEach(x =>
            {
                x.IsSelected = userMapping.Any(z => z.UserID == x.UserID);
            });
            model.UserList = userList;
            return model;
        }

        public bool AddUserList(UserGroupModel model)
        {
            using (var scope = new TransactionScope())
            {
                var userGroups = _userGroupMap.GetWithInclude(x => x.UserGroupID == model.UserGroupID).ToList();
                if (model.UserCheckList.Count == 0)
                {
                    userGroups.ForEach(x =>
                    {
                        _userGroupMap.Delete(Convert.ToInt32(x.Id));

                    });
                    scope.Complete();
                    return true;
                }


                var userGroupList = userGroups.Select(x => x.UserID.Value).ToList();
                var addedList = model.UserCheckList.Except(userGroupList).ToList();
                var deleteList = userGroupList.Except(model.UserCheckList).ToList();
                var usergroupMap = userGroups.Where(x => deleteList.Contains(x.UserID.Value)).Select(x => x.Id).ToList();
                usergroupMap.ForEach(x =>
                {
                    _userGroupMap.Delete(Convert.ToInt32(x));
                });

                addedList.ForEach(x =>
                {
                    UserGroup_Mapping usermap = new UserGroup_Mapping();
                    usermap.UserGroupID = model.UserGroupID;
                    usermap.UserID = x;
                    usermap.IsActive = true;
                    usermap.CreatedOn = DateTime.Now;
                    _userGroupMap.Insert(usermap);
                });
                scope.Complete();

            }
            return true;
        }
    }
}
