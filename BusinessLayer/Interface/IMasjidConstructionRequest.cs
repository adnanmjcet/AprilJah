using System;
using CommonLayer.CommonModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace BusinessLayer.Interface
{
    public interface IMasjidConstructionRequest
    {
        List<MasjidModel> MasjidList();


        //List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        List<MasjidConstructionRequestModel> MasjidConstructionRequestList();

        MasjidConstructionRequestModel GetDetails(MasjidConstructionRequestModel model);

        int Save(MasjidConstructionRequestModel model);

        MasjidConstructionRequestModel GetById(int id);

        //void Delete(MasjidConstructionRequestModel entity);

    }
}
