using System.Collections.Generic;
using System.Linq;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using BusinessLayer.Interface;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLogic.Implementation
{
    public class MadarsaBs : IMadarsa
    {
        private readonly IGenericPattern<Madarsa> _tbl_Madarsa;

        public MadarsaBs()
        {
            _tbl_Madarsa = new GenericPattern<Madarsa>();

        }

        public List<MadarsaModel> MadarsaList()
        {
            List<MadarsaModel> _MadarsaList = new List<MadarsaModel>();
            var MadarsaData = _tbl_Madarsa.GetAll().ToList();
            _MadarsaList = (from item in MadarsaData
                            select new MadarsaModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Location = item.Location,
                                Mobile = item.Mobile,
                                HeadUserId = item.HeadUserId,
                                UserName = (item.User != null) ? item.User.UserName : string.Empty,

                                ZoneName = (item.Zone != null) ? item.Zone.Name : string.Empty,

                                CreatedDate = item.CreatedDate,
                                CreatedBy = item.CreatedBy,

                            }).OrderByDescending(x => x.Id).ToList();
            return _MadarsaList;
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

        //public void Delete(MadarsaModel entity)
        //{
        //    Madarsa AddMadarsaData = new Madarsa(entity);
        //    using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        //    {
        //        if (entity.Id != null && entity.Id != 0)
        //        {
        //            _tbl_Madarsa.Delete(AddMadarsaData.Id);

        //        }
        //        scope.Complete();
        //    }
        //}

        public MadarsaModel GetById(int id)
        {
            MadarsaModel _Madarsa = new MadarsaModel();
            var item = _tbl_Madarsa.GetById(id);
            item = item ?? new Madarsa();
            _Madarsa = new MadarsaModel
            {
                Id = item.Id,
                Name = item.Name,
                Location = item.Location,
                Mobile = item.Mobile,
                HeadUserId = item.HeadUserId,
                UserName = (item.User != null) ? item.User.UserName : string.Empty,

                ZoneName = (item.Zone != null) ? item.Zone.Name : string.Empty,

                CreatedDate = item.CreatedDate,
                CreatedBy = item.CreatedBy,
            };
            return _Madarsa;
        }

        public MadarsaModel GetDetails(MadarsaModel model)
        {
            model = model ?? new MadarsaModel();
            if (model.Id != 0)
            {
                model.MadarsaLists = MadarsaList();
                model.UserLists = UserList();
                model.ZoneLists = ZoneList();
            }
            model.MadarsaLists = MadarsaList();

            return model;
        }


        public int Save(MadarsaModel model)
        {
            Madarsa _tblMadarsa = new Madarsa(model);
            if (model.Id != null && model.Id != 0)
            {
                _tblMadarsa.CreatedDate = System.DateTime.Now;
                _tblMadarsa.CreatedBy = 1;
                _tbl_Madarsa.Update(_tblMadarsa);

            }
            else
            {

                _tblMadarsa.CreatedDate = System.DateTime.Now;
                _tblMadarsa.CreatedBy = 1;

                _tblMadarsa = _tbl_Madarsa.Insert(_tblMadarsa);
            }


            return _tblMadarsa.Id;
        }
    }
}
