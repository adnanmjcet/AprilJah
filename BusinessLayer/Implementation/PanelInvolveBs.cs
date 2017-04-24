using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLayer.Implementation
{
    public class PanelInvolveBs : IPInvolve
    {
        private readonly IGenericPattern<PanelInvolvement> _PanelInvolvement;
        private PanelInvolvementModel _PanelInvolvementModel;
        public PanelInvolveBs()
        {
            _PanelInvolvement = new GenericPattern<PanelInvolvement>();
            _PanelInvolvementModel = new PanelInvolvementModel();
        }

        public PanelInvolvementModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PanelInvolvementModel GetDetails(PanelInvolvementModel model)
        {
            throw new NotImplementedException();
        }

        public List<PanelInvolvementModel> InvolveList()
        {
            List<PanelInvolvementModel> _PanelInvolveList = new List<PanelInvolvementModel>();
            var PList = _PanelInvolvement.GetAll().ToList();
            _PanelInvolveList = (from item in PList
                                 select new PanelInvolvementModel
                           {
                               Id = item.Id,
                               UserTypeId =Convert.ToInt32(item.UserTypeId),
                               UserId= Convert.ToInt32(item.UserId),
                               UserTypeName=item.UserType.Name,
                               UserName=item.User.UserName,
                               RequestSubmitId= Convert.ToInt32(item.RequestSubmitId)

                           }).OrderByDescending(x => x.Id).ToList();
            return _PanelInvolveList;
        }

        public bool IsPanelInvoled(List<int> model)
        {
            var PList = _PanelInvolvement.GetAll().Where(m => model.Contains((Int32)m.UserTypeId));
            if (PList!=null && PList.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PanelInvolvementModel> InvolveList(int id)
        {
            List<PanelInvolvementModel> _PanelInvolveList = new List<PanelInvolvementModel>();
            var PList = _PanelInvolvement.GetAll().Where(x=>x.RequestSubmitId==id).ToList();
            _PanelInvolveList = (from item in PList
                                 select new PanelInvolvementModel
                                 {
                                     Id = item.Id,
                                     UserTypeId = Convert.ToInt32(item.UserTypeId),
                                     UserId = Convert.ToInt32(item.UserId),
                                     UserTypeName = item.UserType.Name,
                                     UserName = item.User.UserName,
                                     RequestSubmitId = Convert.ToInt32(item.RequestSubmitId)

                                 }).OrderByDescending(x => x.Id).ToList();
            return _PanelInvolveList;
        }

        public List<PanelInvolvementModel> PanelMemberInvolveList(int id,int usertypeid)
        {
            List<PanelInvolvementModel> _PanelInvolveList = new List<PanelInvolvementModel>();
            var PList = _PanelInvolvement.GetAll().Where(x => x.RequestSubmitId == id && x.UserTypeId==usertypeid).ToList();
            _PanelInvolveList = (from item in PList
                                 select new PanelInvolvementModel
                                 {
                                     Id = item.Id,
                                     UserTypeId = Convert.ToInt32(item.UserTypeId),
                                     UserId = Convert.ToInt32(item.UserId),
                                     UserTypeName = item.UserType.Name,
                                     UserName = item.User.UserName,
                                     RequestSubmitId = Convert.ToInt32(item.RequestSubmitId)

                                 }).OrderByDescending(x => x.Id).ToList();
            return _PanelInvolveList;
        }

        public List<RequestSubmitModel> RequestSubmitList()
        {
            throw new NotImplementedException();
        }

        public int Save(PanelInvolvementModel model)
        {

            PanelInvolvement _panelInvolvement = new PanelInvolvement(model);
            if (model.Id != null && model.Id != 0)
            {
                _PanelInvolvement.Update(_panelInvolvement);

            }
            else
            {
                _panelInvolvement.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                _PanelInvolvement.Insert(_panelInvolvement);
            }

            return _panelInvolvement.Id;
        }

        public List<UserModel> UserList()
        {
            throw new NotImplementedException();
        }
        public bool IsAlreadyExists(PanelInvolvementModel model)
        {

            var GetList = _PanelInvolvement.FindBy(m => m.UserTypeId == model.UserTypeId && m.RequestSubmitId == model.RequestSubmitId);
            if (GetList!=null && GetList.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
