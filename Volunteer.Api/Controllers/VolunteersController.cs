using Microsoft.AspNetCore.Mvc;
using Volunteer.Entities;
using Volunteer.Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly VolunteerService _service = new VolunteerService();
        // GET: api/<VolunteersController>
        [HttpGet]
        public IEnumerable<MyVolunteer> Get()
        {
            return _service.GetAllVolunteers();
        }

        // GET api/<VolunteersController>/5
        [HttpGet("{id}")]
        public MyVolunteer Get(int id)
        {
            return _service.GetVolunteer(id);
        }

        // POST api/<VolunteersController>
        [HttpPost]
        public void Post([FromBody] MyVolunteer volunteer)
        {
            _service.AddVolunteer(volunteer);
        }

        // PUT api/<VolunteersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string lastName)
        {
            _service.UpdateVolunteer(id, lastName);
        }

        // DELETE api/<VolunteersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
