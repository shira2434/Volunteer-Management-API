using Microsoft.EntityFrameworkCore;
using Volunteer.Entities;

namespace Volunteer.Repository
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly DataContext _context;

        public VolunteerRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MyVolunteer> GetAllVolunteers() =>
            _context.Volunteers.Include(v => v.Role).ToList();

        public void AddVolunteer(MyVolunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();
        }

        public MyVolunteer? GetVolunteer(int id) =>
            _context.Volunteers.Include(v => v.Role).FirstOrDefault(v => v.Id == id);

        public void UpdateVolunteer(int id, MyVolunteer myVolunteer)
        {
            var volunteer = _context.Volunteers.FirstOrDefault(v => v.Id == id);
            if (volunteer != null)
            {
                volunteer.FirstName = myVolunteer.FirstName;
                volunteer.LastName = myVolunteer.LastName;
                volunteer.RoleId = myVolunteer.RoleId;
                _context.SaveChanges();
            }
        }

        public bool DeleteVolunteer(int id)
        {
            var volunteer = _context.Volunteers.FirstOrDefault(v => v.Id == id);
            if (volunteer == null) return false;
            _context.Volunteers.Remove(volunteer);
            _context.SaveChanges();
            return true;
        }
    }
}
