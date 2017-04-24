using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
   public interface IMadarsaLandRequest
    {

        List<MadarsaLandRequestModel> MadarsaLandRequestList();

        List<MadarsaModel> MadarsaList();

        List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        MadarsaLandRequestModel GetDetails(MadarsaLandRequestModel model);

        int Save(MadarsaLandRequestModel model);

        MadarsaLandRequestModel GetById(int id);
    }
}
