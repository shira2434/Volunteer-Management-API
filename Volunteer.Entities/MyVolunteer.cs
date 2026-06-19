using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volunteer.Entities
{
    public class MyVolunteer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public int? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}
 