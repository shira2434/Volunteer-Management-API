using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;
using Volunteer.Repository;

namespace Volunteer.Service
{
    public class VolunteerService
    {
        public IVolunteerRepository repo { get; set; }=new VolunteerRepository();
        public void AddVolunteer(MyVolunteer volunteer) {
            //repo= new VolunteerRepository();
            if (volunteer.LastName == null)
            {
                //firstName="Chani Cohen
                //names=[Chani,Cohen]
                var names=volunteer.FirstName.Split(' ');
                volunteer.FirstName = names[0];
                volunteer.LastName = names[1];
            }
            repo.AddVolunteer(volunteer);
        }

        public IEnumerable<MyVolunteer> GetAllVolunteers()
        {
            var list= repo.GetAllVolunteers();
            foreach (var item in list) {
                item.LastName += "!";
            }
            return list;
        }

        public MyVolunteer GetVolunteer(int id)
        {
            return repo.GetVolunteer(id);
        }

        public void UpdateVolunteer(int id, string lastName)
        {
            var myVolunteer = repo.GetVolunteer(id);
            myVolunteer.LastName=lastName+$" ({myVolunteer.LastName})";
            repo.UpdateVolunteer(id, myVolunteer);
        }
    }
}
