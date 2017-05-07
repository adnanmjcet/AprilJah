using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserCategoryMapping
    {
        List<UserCategoryMappingModel> UserCategoryList();
       
        
        UserCategoryMappingModel GetDetails(UserCategoryMappingModel model);

        int Save(UserCategoryMappingModel model);

        UserCategoryMappingModel GetById(int id);
    }
}
