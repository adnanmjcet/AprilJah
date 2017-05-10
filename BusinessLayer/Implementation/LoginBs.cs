using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLayer.Implementation
{
    public class LoginBs : ILogin
    {
        private readonly IGenericPattern<User> _User;
        private readonly LoginModel _LoginModel;

        public LoginBs()
        {
            _User = new GenericPattern<User>();
            _LoginModel = new LoginModel();
        }

        public LoginModel GetById(int id)
        {
            return _User.GetAll().Where(x => x.Id == id).Select(x => new CommonLayer.CommonModels.LoginModel
            {
                Id = x.Id,
                Name = x.Name,
                DeviceID = x.DeviceID,
                Platform = x.Platform,
                Area = x.Area,

            }).FirstOrDefault();
        }

        public LoginModel GetDetails(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public List<LoginModel> LoginList()
        {
            List<LoginModel> _MadarsaList = new List<LoginModel>();
            List<User> UserList = _User.GetAll().ToList();
            _MadarsaList = (from item in UserList
                            select new LoginModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                UserName = item.UserName,
                                Password = item.Password,
                                RoleId = item.RoleId,
                                UserTypeId = item.UserTypeId,
                                RoleName = item.Role.Name

                            }).OrderByDescending(x => x.Id).ToList();
            return _MadarsaList;

        }

        public UserModel LoginAuthentication(string userName, string password)
        {

            try
            {
                return _User.GetWithInclude(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password).Select(x => new UserModel
                {

                    Id = x.Id,
                    IsOTPCheck = x.IsOTPCheck,

                }).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserModel OTPAuthenticationCheck(string contactNo, string otpPassword)
        {

            try
            {
                return _User.GetAll().Where(x => x.Contact == contactNo && x.OTPPassword == otpPassword).Select(x => new UserModel
                {
                    Id = x.Id,
                    OTPPassword = x.OTPPassword,
                    OTPGeneratedTime = x.OTPGeneratedTime,
                    IsOTPCheck = x.IsOTPCheck,
                    Name = x.Name,
                    Contact = x.Contact,
                    Area = x.Area,
                    Email = x.Email,
                    UserName = x.UserName,
                    Password = x.Password,
                    CreatedDate = x.CreatedDate,
                    DeviceID = x.DeviceID,
                    Platform = x.Platform,
                }).FirstOrDefault();


            }
            catch (Exception)
            {

                throw;
            }
        }



        public int Save(LoginModel model)
        {
            throw new NotImplementedException();
        }



    }

    public class JAHMembershipprovider : MembershipProvider
    {

        LoginBs obj;

        public JAHMembershipprovider()
        {
            obj = new LoginBs();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {

            int count = obj.LoginList().Where(x => x.UserName == username && x.Password == password).ToList().Count();


            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }


    public class JAHRoleProvider : RoleProvider
    {
        LoginBs obj;

        public JAHRoleProvider()
        {
            obj = new LoginBs();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] RoleName = { obj.LoginList().Where(x => x.UserName == username).FirstOrDefault().RoleName };
            return RoleName;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
