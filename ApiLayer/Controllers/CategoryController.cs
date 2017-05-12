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
        public CategoryController()
        {
            _categoryModel = new CategoryModel();
            _categoryBs = new CategoryBs();
            _userCategoryBs = new UserCategoryMappingBs();
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
            
            return Ok(categorys);
        }
        [HttpPost]
        public IHttpActionResult Post(int userID, List<CategoryModel> model)
        {
            int userid = userID;
            _categoryBs.UpdateCategory(model,userid);

            return Ok();
        }


    }
}
