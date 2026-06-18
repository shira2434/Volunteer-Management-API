using Volunteer.Entities;
using Volunteer.Repository;

namespace Volunteer.Service
{
    public class VolunteerService
    {
        private readonly IVolunteerRepository _repo;

        public VolunteerService(IVolunteerRepository repo)
        {
            _repo = repo;
        }

        public void AddVolunteer(VolunteerDto dto)
        {
            var volunteer = new MyVolunteer();

            if (!string.IsNullOrWhiteSpace(dto.FullName) && string.IsNullOrWhiteSpace(dto.LastName))
            {
                var names = dto.FullName.Split(' ', 2);
                volunteer.FirstName = names[0];
                volunteer.LastName = names.Length > 1 ? names[1] : string.Empty;
            }
            else
            {
                volunteer.FirstName = dto.FirstName ?? string.Empty;
                volunteer.LastName = dto.LastName ?? string.Empty;
            }

            _repo.AddVolunteer(volunteer);
        }

        public IEnumerable<MyVolunteer> GetAllVolunteers()
        {
            var list = _repo.GetAllVolunteers().ToList();
            foreach (var item in list)
                item.LastName += "!";
            return list;
        }

        public MyVolunteer? GetVolunteer(int id) => _repo.GetVolunteer(id);

        public bool UpdateVolunteer(int id, string lastName)
        {
            var volunteer = _repo.GetVolunteer(id);
            if (volunteer == null) return false;
            volunteer.LastName = $"{lastName} ({volunteer.LastName})";
            _repo.UpdateVolunteer(id, volunteer);
            return true;
        }

        public bool DeleteVolunteer(int id) => _repo.DeleteVolunteer(id);
    }
}
