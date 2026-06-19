using System.ComponentModel.DataAnnotations;

namespace Volunteer.Entities
{
    public class VolunteerDto
    {
        [StringLength(100)]
        public string? FullName { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public int? RoleId { get; set; }
    }
}
