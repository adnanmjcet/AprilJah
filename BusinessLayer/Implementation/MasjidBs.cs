using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class MasjidBs : IMasjid
    {
        private readonly IGenericPattern<Masjid> _tbl_Masjid;
        private MasjidModel _Masjid;
        public MasjidBs()
        {
            _tbl_Masjid = new GenericPattern<Masjid>();
            _Masjid = new MasjidModel();
        }


        public List<MasjidModel> MasjidList()
        {
            List<MasjidModel> _MasjidList = new List<MasjidModel>();
            var MasjidData = _tbl_Masjid.GetAll().ToList();
            _MasjidList = (from item in MasjidData
                           select new MasjidModel
                           {

                               Id = item.Id,
                               Name = item.Name,
                               Location = item.Location,
                               HeadUserId = item.HeadUserId,
                               UserName = (item.User != null) ? item.User.UserName : string.Empty,
                               ZoneId = item.ZoneId,
                               ZoneName = (item.Zone != null) ? item.Zone.Name : string.Empty,
                               Mobile = item.Mobile,
                               CreatedDate = item.CreatedDate,
                               CreatedBy = item.CreatedBy,
                           }).OrderByDescending(x => x.Id).ToList();
            return _MasjidList;
        }


        public List<ZoneModel> ZoneList()
        {
            GenericPattern<Zone> _tbl_Zone = new GenericPattern<Zone>();
            List<ZoneModel> _ZoneList = new List<ZoneModel>();
            var ZoneData = _tbl_Zone.GetAll().ToList();
            _ZoneList = (from item in ZoneData
                         select new ZoneModel
                         {
                             Id = item.Id,
                             Name = item.Name,

                         }).OrderByDescending(x => x.Id).ToList();
            return _ZoneList;
        }

        public List<UserModel> UserList()
        {
            GenericPattern<User> _tbl_User = new GenericPattern<User>();
            List<UserModel> _UserList = new List<UserModel>();
            var UserData = _tbl_User.GetAll().ToList();
            _UserList = (from item in UserData
                         select new UserModel
                         {
                             Id = item.Id,
                             Name = item.Name,

                         }).OrderByDescending(x => x.Id).ToList();
            return _UserList;
        }

        public MasjidModel GetDetails(MasjidModel model)
        {
            model = model ?? new MasjidModel();
            if (model.Id != 0)
            {
                model.MasjidLists = MasjidList();
                model.ZoneLists = ZoneList();
                model.UserLists = UserList();
            }
            model.MasjidLists = MasjidList();

            return model;

        }

        public int Save(MasjidModel model)
        {
            Masjid _tbl_masjid = new Masjid(model);
            if (model.Id != null && model.Id != 0)
            {
                _tbl_Masjid.Update(_tbl_masjid);

            }
            else
            {
                _tbl_masjid.CreatedDate = System.DateTime.Now;
                 _tbl_Masjid.Insert(_tbl_masjid);
            }

            return _tbl_masjid.Id;
        }

        public MasjidModel GetById(int id)
        {
            MasjidModel _Halqa = new MasjidModel();
            var MasjidbyId = _tbl_Masjid.GetById(id);
          

            _Masjid = new MasjidModel
            {
                Id = MasjidbyId.Id,
                Name = MasjidbyId.Name,
                Location = MasjidbyId.Location,
                HeadUserId = MasjidbyId.HeadUserId,
                UserName = (MasjidbyId.User != null) ? MasjidbyId.User.UserName : string.Empty,
                ZoneId = MasjidbyId.ZoneId,
                ZoneName = (MasjidbyId.Zone != null) ? MasjidbyId.Zone.Name : string.Empty,
                Mobile = MasjidbyId.Mobile,
                CreatedDate = MasjidbyId.CreatedDate,
                CreatedBy = MasjidbyId.CreatedBy,
            };
            return _Masjid;
        }
    }
}