using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMadarsaExtenstionRequest
    {
        List<MadarsaExtensionRequestModel> MadarsaExtensionRequestList();
        List<MadarsaModel> MadarsaList();

        List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        MadarsaExtensionRequestModel GetDetails(MadarsaExtensionRequestModel model);

        int Save(MadarsaExtensionRequestModel model);

        MadarsaExtensionRequestModel GetById(int id);

        MadarsaExtensionRequestModel GetByRequestSubmitId(int id, int userid);
    }
}
