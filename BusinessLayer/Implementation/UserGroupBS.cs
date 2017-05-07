using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
   public class UserGroupBS : IUserGroupBS
    {
       private readonly IGenericPattern<UserGroup> _userGroup;
       private readonly IGenericPattern<UserGroup_Mapping> _userGroupMap;

       public UserGroupBS()
       {
           _userGroup = new GenericPattern<UserGroup>();
           _userGroupMap = new GenericPattern<UserGroup_Mapping>();
       }

       public List<UserGroupModel> UserGroupList()
       {
           return _userGroup.GetWithInclude(x => x.IsActive == false).Select(x => new UserGroupModel
           {
               Id = x.Id,
               Name = x.Name,
               CreatedOn = x.CreatedOn,
           }).ToList();
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
               _userGroup.Update(_tbl_userGroup);
              
           }
           else
           {
               _tbl_userGroup.IsActive = false;
               _tbl_userGroup.CreatedOn = System.DateTime.Now;
               _userGroup.Insert(_tbl_userGroup);
           }

           return _tbl_userGroup.Id;
       }
    }
}
