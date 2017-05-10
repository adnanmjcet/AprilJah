using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
  public  interface ILogin
    {
        List<LoginModel> LoginList();

        LoginModel GetDetails(LoginModel model);

        int Save(LoginModel model);

        LoginModel GetById(int id);

        UserModel LoginAuthentication(string userName, string password);
        UserModel OTPAuthenticationCheck(string contactNo, string otpPassword);
    }
}
