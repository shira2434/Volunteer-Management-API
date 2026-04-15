using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Volunteer.Repository
{
    public class VolunteerRepository:IVolunteerRepository
    {
        public IEnumerable<MyVolunteer> GetAllVolunteers()
        {
            return DataContext.Volunteers;
        }

        public void AddVolunteer(MyVolunteer volunteer)
        {
            DataContext.Volunteers.Add(volunteer);
        }

        public MyVolunteer GetVolunteer(int id)
        {
            return DataContext.Volunteers.Where(MyVolunteer => MyVolunteer.Id == id).FirstOrDefault();
        }

        public void UpdateVolunteer(int id, MyVolunteer myVolunteer)
        {
            var volunteer = DataContext.Volunteers.Where(MyVolunteer => MyVolunteer.Id == id).FirstOrDefault();
            if (volunteer != null)
            {
                volunteer.FirstName = myVolunteer.FirstName;
                volunteer.LastName = myVolunteer.LastName;
            }
        }
    }
}
