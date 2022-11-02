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
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get all events.");
            }                        
        }

        /// <summary>
        /// Get all events by organizer
        /// </summary>
        /// <param name="id">the id of the organizer</param>
        /// <returns>A collection of events by the organizer</returns>
        [HttpGet]
        [Route("/GetAllByOrganizer")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEventsByOrganizer(int id)
        {
            try
            {
                var allEventsByOrganizer = await eventRepository.GetEventsByOrganizerAsync(id);
                return Ok(allEventsByOrganizer);
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get all events by organizer.");
            }
        }

        /// <summary>
        /// Adds an event
        /// </summary>
        /// <param name="event">the event to add</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/AddEvent")]
        public async Task<IActionResult> AddEvent(Event @event)
        {
            try
            {
                await eventRepository.InsertAsync(@event);
                await eventRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to add event.");
            }
        }

        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="event">the updated event</param>
        /// <returns></returns>
        [HttpPut]
        [Route("/UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(Event @event)
        {
            try
            {
                await eventRepository.UpdateAsync(@event);
                await eventRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to update the event");
            }
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="id">the id of the event to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                await eventRepository.DeleteAsync(id);
                await eventRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to delete the event");
            }
        }
    }
}