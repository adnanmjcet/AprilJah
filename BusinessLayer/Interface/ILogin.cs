using CommonLayer.CommonModels;
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

        int LoginAuthentication(string userName, string password);
    }
}
