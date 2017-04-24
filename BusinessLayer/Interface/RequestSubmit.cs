using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IRequestSubmit
    {
        List<RequestSubmitModel> RequestSubmitList();
        //RequestSubmitModel GetById(int id);

        List<RequestSubmitModel> AmeerApprovedList();

        List<RequestSubmitModel> AmeerRejectedList();

    }
}
