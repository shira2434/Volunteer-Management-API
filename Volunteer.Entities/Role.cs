using System.ComponentModel.DataAnnotations;

namespace Volunteer.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<MyVolunteer> Volunteers { get; set; } = new List<MyVolunteer>();
    }
}
