using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
   public interface IVolunteer
    {
        List<VolunteerModel> VolunteerList();

        VolunteerModel GetDetails(VolunteerModel model);

        int Save(VolunteerModel model);

        VolunteerModel GetById(int id);
    }
}
