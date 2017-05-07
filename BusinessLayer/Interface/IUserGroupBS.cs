using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
namespace BusinessLayer.Implementation
{
   public interface IUserGroupBS
    {
        UserGroupModel GetById(int id);
        long Save(UserGroupModel model);
       List<UserGroupModel> UserGroupList();
        UserGroupModel GetUserList(Int64 userGroupID);
    }
}
