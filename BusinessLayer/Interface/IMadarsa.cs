using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMadarsa
    {
        List<MadarsaModel> MadarsaList();

        List<ZoneModel> ZoneList();

        List<UserModel> UserList();

        MadarsaModel GetDetails(MadarsaModel model);

        int Save(MadarsaModel model);

        MadarsaModel GetById(int id);
    }
}
