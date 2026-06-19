using Microsoft.AspNetCore.Mvc;
using Volunteer.Entities;
using Volunteer.Service;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _service;

        public RolesController(RoleService service)
        {
            _service = service;
        }

        // GET: api/roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get() => Ok(_service.GetAllRoles());

        // GET api/roles/5
        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            var role = _service.GetRole(id);
            if (role == null) return NotFound($"Role with id {id} not found");
            return Ok(role);
        }

        // POST api/roles
        [HttpPost]
        public ActionResult Post([FromBody] string name)
        {
            _service.AddRole(name);
            return StatusCode(201, "Role added successfully");
        }

        // DELETE api/roles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_service.DeleteRole(id))
                return NotFound($"Role with id {id} not found");
            return NoContent();
        }
    }
}
