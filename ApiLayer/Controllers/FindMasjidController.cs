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
    public class FindMasjidController : ApiController
    {
        private readonly MasjidBs _masjid;

        APIResponseModel apiResponse;

        public FindMasjidController()
        {
            _masjid = new MasjidBs();
            apiResponse = new APIResponseModel();
        }
        // GET: FindMasjid
       [HttpGet]
        public IHttpActionResult MasjidList()
        {
            var res = _masjid.MasjidList().ToList();

            if (res!=null)
            {
                apiResponse.Data = res;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "List of Masjid Records Found";
            }
            else
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "No Records Found";
            }

            return Ok(apiResponse);
            
        }
    }
}