using System;
namespace BusinessLayer.Implementation
{
   public interface IUserGroupBS
    {
        CommonLayer.CommonModels.UserGroupModel GetById(int id);
        long Save(CommonLayer.CommonModels.UserGroupModel model);
        System.Collections.Generic.List<CommonLayer.CommonModels.UserGroupModel> UserGroupList();
    }
}
