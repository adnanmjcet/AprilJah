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
    public class AccountController : ApiController
    {
        private readonly UserModel _userModel;
        private readonly UserRegistrationBs _userRegistrationBs;
        private readonly LoginBs _loginBs;
        public AccountController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
            _loginBs = new LoginBs();
        }

        [HttpPost]
        [Route("api/account/UserRegistration")]
        public IHttpActionResult UserRegistration(UserModel model)
        {
            int res = 0;
            if (model != null)
            {
                res = _userRegistrationBs.Save(model);
            }
            if (res != 0)
                return Ok("User Registered Successfully !");
            else
                return Ok("User Registration Failed");
        }


        [HttpPost]
        [Route("api/account/Login")]
        public IHttpActionResult Login(UserModel model)
        {

            int res = _loginBs.LoginAuthentication(model.UserName, model.Password);

            if (res != 0)
                return Ok("Login Successfully!");
            else
                return Ok("User Or Password Incorrect!");
            //if (Membership.ValidateUser(model.UserName, model.Password))
            //    return Ok("Login Successfully!");
            //else
            //    return Ok("User Or Password Incorrect!");


        }


        [HttpGet]
        public IHttpActionResult GetLogout()
        {

            // update device id as null  of user    
            int userid = User.Identity.GetUserID();

            Int64? accountID = null;

            var useraccountdata = _userRegistrationBs.GetById(userid);
            if (useraccountdata != null)
            {
                useraccountdata.DeviceID = string.Empty;
                useraccountdata.Platform = 0;
            }
            _userRegistrationBs.Save(useraccountdata);

            return Ok();

        }


        [ActionName("DefaultAction")]
        public IHttpActionResult GetAddPlatform(string deviceid, string platform)
        {

            // update device id and platform of user  for push notification    
            int userid = User.Identity.GetUserID();


            var useraccountdata = _userRegistrationBs.GetById(userid);
            if (useraccountdata != null)
            {
                useraccountdata.DeviceID = deviceid;
                useraccountdata.Platform = Convert.ToInt32(platform);
            }
            _userRegistrationBs.Save(useraccountdata);
            return Ok();

        }
    }
}
