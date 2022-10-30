using Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    public class EventController : Controller
    {
        /// <summary>
        /// Gets all events
        /// </summary>
        /// <returns>A collection of all events.</returns>
        [HttpGet]
        [Route("/GetAll")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            // TODO: replace this with the repo/UoW pattern:
            try
            {                
                EcpContext context = new();
                var allEvents = await context.Events.ToListAsync();
                return Ok(allEvents);              
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occured attempting to get all events.");
            }                        
        }
    }
}