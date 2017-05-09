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
    public class VolunteerController : ApiController
    {
        private readonly VolunteerModel _VolunteerModel;
        private readonly VolunteerBs _VolunteerBs;
        private readonly MasjidBs _MasjidBs;



        public VolunteerController()
        {
            _VolunteerModel = new VolunteerModel();
            _VolunteerBs = new VolunteerBs();
            _MasjidBs = new MasjidBs();
        }
        [HttpPost]
        public IHttpActionResult AddVolunteer(VolunteerModel model)
        {
            int res = 0;
            if (model != null)
            {
                res = _VolunteerBs.Save(model);
            }
            if (res > 0)
            {
                return Ok("Volunteer Added Successfully");
            }
            else
            {
                return Ok("Volunteer Addition Failed");
            }

        }

        [HttpGet]
        public IEnumerable<ZoneModel> ZoneList()
        {

            var res = _MasjidBs.ZoneList().ToList();

            return res;

        }
    }
}
