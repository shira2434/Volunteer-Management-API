namespace Volunteer.Entities
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role? GetRole(int id);
        void AddRole(Role role);
        bool DeleteRole(int id);
    }
}
