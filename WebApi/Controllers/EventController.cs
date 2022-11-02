using DataAccess;
using Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    public class EventController : Controller
    {
        EventRepository eventRepository = new(new());
        /// <summary>
        /// Gets all events
        /// </summary>
        /// <returns>A collection of all events.</returns>
        [HttpGet]
        [Route("/GetAll")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            try
            {                
                var allEvents = await eventRepository.GetAllAsync();
                return Ok(allEvents);              
            }
            catch (Exception e)
            {
                //Log the exception
                return StatusCode(500, $"An error occured attempting to get all events.");
            }                        
        }
    }
}