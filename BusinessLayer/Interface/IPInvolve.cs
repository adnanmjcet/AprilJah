using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
   public interface IPInvolve
    {
        List<PanelInvolvementModel> InvolveList();

        List<PanelInvolvementModel> InvolveList(int id);

        List<UserModel> UserList();

        List<RequestSubmitModel> RequestSubmitList();

        PanelInvolvementModel GetDetails(PanelInvolvementModel model);

        int Save(PanelInvolvementModel model);

        PanelInvolvementModel GetById(int id);

        bool IsAlreadyExists(PanelInvolvementModel model);
    }
}
