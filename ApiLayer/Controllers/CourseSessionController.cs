using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLayer.Controllers
{
    public class CourseSessionController : ApiController
    {
        private readonly CourseSessionBs _courseSessionBs;
        private readonly CourseSessionModel _courseSessionModel;
        APIResponseModel apiResponse;

        public CourseSessionController()
        {
            _courseSessionBs = new CourseSessionBs();
            _courseSessionModel = new CourseSessionModel();
            apiResponse = new APIResponseModel();
        }

        [HttpGet]
        public IHttpActionResult GetCourseSession(Int64 topicID)
        {
            CourseSessionModel model = new CourseSessionModel();
            var sessionData = _courseSessionBs.GetById(topicID);
            if (sessionData == null)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "No Session Found";
            }
            model.Topic = sessionData.Topic;
            model.VideoLink = sessionData.VideoLink;
            model.AudioLink = sessionData.AudioLink;
            model.Document1 = sessionData.Document1 != null ? ConfigurationManager.AppSettings["BaseUrl"] + "/Documents" + "/" + sessionData.Document1 : string.Empty;
            model.Document2 = sessionData.Document2 != null ? ConfigurationManager.AppSettings["BaseUrl"] + "/Documents" + "/" + sessionData.Document2 : string.Empty;
            //sessionData.Document1 = "";// update with url
            //sessionData.Document2 = "";//same

            apiResponse.IsSuccess = true;
            apiResponse.Data = model;
            return Ok(apiResponse);
        }
    }
}
