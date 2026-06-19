using Volunteer.Entities;

namespace Volunteer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles() => _context.Roles.ToList();

        public Role? GetRole(int id) => _context.Roles.FirstOrDefault(r => r.Id == id);

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public bool DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null) return false;
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
    }
}
