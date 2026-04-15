using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.Entities
{
    public interface IVolunteerRepository
    {
        void AddVolunteer(MyVolunteer volunteer);
        IEnumerable<MyVolunteer> GetAllVolunteers();
        MyVolunteer GetVolunteer(int id);
        void UpdateVolunteer(int id, MyVolunteer myVolunteer);
    }
}
