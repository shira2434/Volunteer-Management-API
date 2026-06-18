using Microsoft.AspNetCore.Mvc;
using Volunteer.Entities;
using Volunteer.Service;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly VolunteerService _service;

        public VolunteersController(VolunteerService service)
        {
            _service = service;
        }

        // GET: api/volunteers
        [HttpGet]
        public ActionResult<IEnumerable<MyVolunteer>> Get()
        {
            return Ok(_service.GetAllVolunteers());
        }

        // GET api/volunteers/5
        [HttpGet("{id}")]
        public ActionResult<MyVolunteer> Get(int id)
        {
            var volunteer = _service.GetVolunteer(id);
            if (volunteer == null) return NotFound($"Volunteer with id {id} not found");
            return Ok(volunteer);
        }

        // POST api/volunteers
        [HttpPost]
        public ActionResult Post([FromBody] VolunteerDto dto)
        {
            _service.AddVolunteer(dto);
            return StatusCode(201, "Volunteer added successfully");
        }

        // PUT api/volunteers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string lastName)
        {
            if (!_service.UpdateVolunteer(id, lastName))
                return NotFound($"Volunteer with id {id} not found");
            return NoContent();
        }

        // DELETE api/volunteers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_service.DeleteVolunteer(id))
                return NotFound($"Volunteer with id {id} not found");
            return NoContent();
        }
    }
}
