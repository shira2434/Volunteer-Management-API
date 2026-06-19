using Volunteer.Entities;

namespace Volunteer.Service
{
    public class RoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Role> GetAllRoles() => _repo.GetAllRoles();

        public Role? GetRole(int id) => _repo.GetRole(id);

        public void AddRole(string name) => _repo.AddRole(new Role { Name = name });

        public bool DeleteRole(int id) => _repo.DeleteRole(id);
    }
}
