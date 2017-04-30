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
        
        public IHttpActionResult UserRegistration(UserModel model)
        {
            int res = 0;
            string otp = null;
            if (model != null)
            {
                otp = GetOTPPassword();
                model.OTPPassword = otp;
                model.OTPGeneratedTime = DateTime.Now;
                model.IsOTPCheck = false;
                res = _userRegistrationBs.Save(model);
            }
            if (res != 0)
                return Ok("User Registered Successfully and OTP is " + otp);
            else
                return Ok("User Registration Failed");
        }


        [HttpPost]
        
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
        [ActionName("DefaultAction")]
        public IHttpActionResult OTPAuthentication(string contactNo, string otpPassword)
        {
            var user = _loginBs.OTPAuthenticationCheck(contactNo, otpPassword);

            if (user != null)
            {
                DateTime OTPTime = user.OTPGeneratedTime.Value;
                DateTime expTime = OTPTime.AddMinutes(15);
                if (DateTime.Now <= expTime)
                {
                    int userid = User.Identity.GetUserID();

                    var useraccountdata = _userRegistrationBs.GetById(userid);
                    if (useraccountdata != null)
                    {
                        useraccountdata.IsOTPCheck = true;
                    }
                    _userRegistrationBs.Save(useraccountdata);

                    return Ok("OTP Password Varified Successfylly!");
                }
                else
                {
                    return Ok("Your OTP Password is expired!");
                }

            }
            else
            {
                return Ok("OTP Password is incorect!");
            }


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

        [HttpGet]
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

        [NonAction]
        public string GetOTPPassword()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;

            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
    }
}
