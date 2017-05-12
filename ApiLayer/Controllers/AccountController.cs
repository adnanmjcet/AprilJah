using ApiLayer.Helpers;
using BusinessLayer.Extension;
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
        APIResponseModel apiResponse;
        public AccountController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
            _loginBs = new LoginBs();
            apiResponse = new APIResponseModel();
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
                var checkUserName = _userRegistrationBs.CheckUserName(model.UserName);
                if (checkUserName)
                    return Ok("UserName alreay exsist!");
                res = _userRegistrationBs.Save(model);
                new SendSMS().Send(model.Contact, "OTP is " + otp + " for Registration");
            }
            if (res != 0)
                return Ok("User Registered Successfully and OTP is " + otp);
            else
                return Ok("User Registration Failed");
        }


        [HttpPost]

        public IHttpActionResult Login(UserModel model)
        {

            var userData = _loginBs.LoginAuthentication(model.UserName, model.Password);

            if (userData != null)
            {
                if (userData.IsOTPCheck == false)
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = "OTP Not Verified!";
                    return Ok(apiResponse);
                }

                apiResponse.Data = userData.Id;
                apiResponse.IsSuccess = true;
                return Ok(apiResponse);
            }

            else
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "User Or Password Incorrect!!";
                return Ok(apiResponse);
            }

            //if (Membership.ValidateUser(model.UserName, model.Password))
            //    return Ok("Login Successfully!");
            //else
            //    return Ok("User Or Password Incorrect!");


        }

        [HttpGet]
        public IHttpActionResult OTPAuthentication(string contactNo, string otpPassword)
        {
            var user = _loginBs.OTPAuthenticationCheck(contactNo, otpPassword);

            if (user != null)
            {
                DateTime OTPTime = user.OTPGeneratedTime.Value;
                DateTime expTime = OTPTime.AddMinutes(15);
                if (DateTime.Now <= expTime)
                {
                    //int userid = User.Identity.GetUserID();
                    //int userid = user.Id;

                    //var useraccountdata = _userRegistrationBs.GetById(userid);
                    //if (useraccountdata != null)
                    //{
                    //    useraccountdata.IsOTPCheck = true;

                    user.IsOTPCheck = true;
                    _userRegistrationBs.Save(user);
                    apiResponse.IsSuccess = true;
                    apiResponse.Data = user.Id;
                    apiResponse.Message = "OTP Password Varified Successfylly!";
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = "Your OTP Password is expired!";
                    return Ok(apiResponse);
                }

            }
            else
            {
                return Ok("OTP Password is incorect!");
            }


        }

        [HttpGet]
        public IHttpActionResult GetLogout(int userid)
        {

            // update device id as null  of user    
            var response = _userRegistrationBs.UpdateUser(userid, null, null);
            if (!response)
            {
                apiResponse.IsSuccess = response;
                apiResponse.Message = "User Not Found!";
            }
            apiResponse.IsSuccess = response;
            return Ok(response);

        }

        [HttpGet]
        public IHttpActionResult GetAddPlatform(int userID, string deviceid, string platform)
        {

            // update device id and platform of user  for push notification    
            //int userid = User.Identity.GetUserID();
            var response = _userRegistrationBs.UpdateUser(userID, deviceid, platform);
            if (!response)
            {
                apiResponse.IsSuccess = response;
                apiResponse.Message = "User Not Found!";
            }
            apiResponse.IsSuccess = response;
            return Ok(apiResponse);
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
