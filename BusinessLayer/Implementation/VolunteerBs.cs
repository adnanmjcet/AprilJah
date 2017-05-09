using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLayer.Implementation
{
    public class VolunteerBs : IVolunteer
    {
        private readonly IGenericPattern<Volunteer> _Volunteer;
        private VolunteerModel _VolunteerModel;
        public VolunteerBs()
        {
            _Volunteer = new GenericPattern<Volunteer>();
            _VolunteerModel = new VolunteerModel();
        }
        public VolunteerModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public VolunteerModel GetDetails(VolunteerModel model)
        {
            throw new NotImplementedException();
        }

        public int Save(VolunteerModel model)
        {
            Volunteer _volunteer = new Volunteer(model);
            if (model.Id != null && model.Id != 0)
            {
                _Volunteer.Update(_volunteer);

            }
            else
            {
                _volunteer.CreatedDate = System.DateTime.Now;
                _Volunteer.Insert(_volunteer);
            }

            return _volunteer.Id;
        }

        public List<VolunteerModel> VolunteerList()
        {
            throw new NotImplementedException();
        }
    }
}
