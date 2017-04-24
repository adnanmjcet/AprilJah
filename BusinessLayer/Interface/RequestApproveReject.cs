using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface RequestApproveReject
    {

        List<RequestApproveModel> RequestApprovedList();

        List<RequestApproveModel> ApproveRejectDisplay(int id);

        List<RequestApproveModel> RequestRejectedList();

        RequestApproveModel GetDetails(RequestApproveModel model);

        int Save(RequestApproveModel model);

        RequestApproveModel GetById(int id);
    }
}
