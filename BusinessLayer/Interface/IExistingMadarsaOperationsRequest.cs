using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IExistingMadarsaOperationsRequest
    {
        List<ExistingMadarsaOperationsRequestModel> ExistingMadarsaOperationRequestList();

        List<MadarsaModel> MadarsaList();

        List<RequestSubmitModel> RequestSubmitList();

        List<RequestTypeModel> RequestTypeList();

        List<UserModel> UserList();

        ExistingMadarsaOperationsRequestModel GetDetails(ExistingMadarsaOperationsRequestModel model);

        int Save(ExistingMadarsaOperationsRequestModel model);

        ExistingMadarsaOperationsRequestModel GetById(int id);
    }
}
