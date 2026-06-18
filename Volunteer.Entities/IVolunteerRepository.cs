namespace Volunteer.Entities
{
    public interface IVolunteerRepository
    {
        void AddVolunteer(MyVolunteer volunteer);
        IEnumerable<MyVolunteer> GetAllVolunteers();
        MyVolunteer? GetVolunteer(int id);
        void UpdateVolunteer(int id, MyVolunteer myVolunteer);
        bool DeleteVolunteer(int id);
    }
}
