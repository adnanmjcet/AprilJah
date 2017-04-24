using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INewMadarsaOperationsRequest
    {
        List<NewMadarsaOperationsRequestModel> NewMadarsaOperationRequestList();

        List<MadarsaModel> MadarsaList();

        List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        NewMadarsaOperationsRequestModel GetDetails(NewMadarsaOperationsRequestModel model);

        int Save(NewMadarsaOperationsRequestModel model);

        NewMadarsaOperationsRequestModel GetById(int id);

    }
}
