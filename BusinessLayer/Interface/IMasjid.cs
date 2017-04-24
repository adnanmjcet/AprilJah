using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMasjid
    {
        List<MasjidModel> MasjidList();

        List<ZoneModel> ZoneList();

        List<UserModel> UserList();

        MasjidModel GetDetails(MasjidModel model);

        int Save(MasjidModel model);

        MasjidModel GetById(int id);

        //void Delete(MasjidModel entity);

    }
}
