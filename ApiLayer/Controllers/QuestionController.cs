using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Implementation;
using CommonLayer.CommonModels;


namespace ApiLayer.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly CourseTestModel _courseTestModel;
        private readonly CourseTestBs _courseTestBs;
        private readonly CourseBs _courseBs;

        APIResponseModel apiResponse;
        public QuestionController()
        {
            _courseTestModel = new CourseTestModel();
            _courseTestBs = new CourseTestBs();
            apiResponse = new APIResponseModel();
            _courseBs = new CourseBs();
        }

        [HttpGet]

        public IHttpActionResult GetQuestionByCourse()
        {
            var courseID = _courseBs.GetActiveCourse();
            if (courseID == 0)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "No active course avaliable!";
            }
            var response = _courseTestBs.GetCourseTestList(courseID);
            if (response != null)
            {
                apiResponse.IsSuccess = true;
                apiResponse.Data = response;
            }
            else
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "Question Not Found!";
            }
            return Ok(apiResponse);
        }


    }
}
