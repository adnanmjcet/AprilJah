using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMasjidRenovationRequest
    {

        List<MasjidModel> MasjidList();


        //List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        List<MasjidRenovationRequestModel> MasjidRenovationRequestList();

        MasjidRenovationRequestModel GetDetails(MasjidRenovationRequestModel model);

        int Save(MasjidRenovationRequestModel model);

        MasjidRenovationRequestModel GetById(int id);

        //void Delete(MasjidRenovationRequestModel entity);
    }
}
