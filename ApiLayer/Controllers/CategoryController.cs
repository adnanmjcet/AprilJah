using ApiLayer.Helpers;
using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiLayer.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryModel _categoryModel;
        private readonly CategoryBs _categoryBs;
        private readonly UserCategoryMappingBs _userCategoryBs;
        APIResponseModel apiResponse;
        public CategoryController()
        {
            _categoryModel = new CategoryModel();
            _categoryBs = new CategoryBs();
            _userCategoryBs = new UserCategoryMappingBs();
            apiResponse = new APIResponseModel();
        }
        [HttpGet]
        public IHttpActionResult GetAllCategory(int userID)
        {
            int userid = userID;
            var categorys = _categoryBs.CategoryList();

            var UserCategory = _userCategoryBs.UserCategoryList().Where(x => x.UserID == userid).Select(x => x).ToList();
            categorys.ForEach(x => 
            {
                x.IsChecked = UserCategory.Any(z => z.UserID == userid && z.CategoryID == x.Id && z.IsSelected == true);
            });

            apiResponse.Data = categorys;
            apiResponse.IsSuccess = true;
            return Ok(apiResponse);
        }
        [HttpPost]
        public IHttpActionResult Post(CategoryModel model)
        {
             _categoryBs.UpdateCategory(model);
            apiResponse.IsSuccess = true;
            apiResponse.Message = "Successfully Updated";
            return Ok(apiResponse);
        }

        [HttpGet]
        public IHttpActionResult GetAllCategory()
        {
           var res= _categoryBs.CategoryList().ToList();
            if (res!=null)
            {
                apiResponse.Data = res;
                apiResponse.Message = "List of Categories found";
                return Ok(apiResponse);
            }
            else
            {
                 apiResponse.Message = "No Categories found";
                return Ok(apiResponse);
            }
           
        }

    }
}
