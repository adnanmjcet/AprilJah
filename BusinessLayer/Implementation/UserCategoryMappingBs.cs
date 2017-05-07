using BusinessLayer.Interface;
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
    public class UserCategoryMappingBs : IUserCategoryMapping
    {
        private readonly IGenericPattern<UserCategoryMapping> _userCategory;
        //private readonly CategoryModel _CategoryModel;


        public UserCategoryMappingBs()
        {
            _userCategory = new GenericPattern<UserCategoryMapping>();
            //_CategoryModel = new CategoryModel();
        }
        public UserCategoryMappingModel GetById(int id)
        {
            return _userCategory.GetAll().Where(x => x.Id == id).Select(x => new UserCategoryMappingModel
            {
                Id = x.Id,
                CategoryID = x.CategoryID,
                UserID = x.UserID,
                IsSelected = x.IsSelected
            }).FirstOrDefault();
        }

        public UserCategoryMappingModel GetDetails(UserCategoryMappingModel model)
        {
            throw new NotImplementedException();
        }

        public int Save(UserCategoryMappingModel model)
        {
            UserCategoryMapping _tbl_usercategory = new UserCategoryMapping(model);
            if (model.Id != null && model.Id != 0)
            {
                _userCategory.Update(_tbl_usercategory);

            }
            else
            {

                _userCategory.Insert(_tbl_usercategory);
            }

            return _tbl_usercategory.Id;
        }

        public List<UserCategoryMappingModel> UserCategoryList()
        {
            return _userCategory.GetAll().Select(x => new UserCategoryMappingModel
            {
                Id = x.Id,
                CategoryID = x.CategoryID,
                UserID = x.UserID,
                IsSelected = x.IsSelected
            }).ToList();
        }
    }
}
