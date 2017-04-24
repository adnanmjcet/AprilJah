using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CommonModels
{
   public class UserModel
    {

        public int Id { get; set; }

        public int MainUserType { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Area { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassord { get; set; }

        public int? RoleId { get; set; }

        public string RoleName { get; set; }


        public int? UserTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }


        //public List<RoleModel> RoleList { get; set; }

        //public List<UserTypeModel> UserTypeList { get; set; }
        public List<UserModel> UserLists { get; set; }


    }
}
