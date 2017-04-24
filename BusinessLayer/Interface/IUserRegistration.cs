using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserRegistration
    {
       

        List<UserModel> UserRegistrationList();

        UserModel GetDetails(UserModel model);

        int Save(UserModel model);

        UserModel GetById(int id);
    }
}
