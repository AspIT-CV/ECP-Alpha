using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository userRepository = new(new());

        [HttpGet("ESeekingV")]//GET: api/User/ESeekingV
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsSeekingVolounteers()
        {
            try
            {
                return Ok(await userRepository.GetEventsSeekingVolunteers());
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occured attempting to get events seeking volunteers\n{e}");
            }
        } 
    }
}
