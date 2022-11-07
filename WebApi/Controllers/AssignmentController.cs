using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        AssignmentRepository assignmentRepository = new(new());

        [HttpGet("{eventId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignmentsByEvent(int eventId)
        {
            try
            {
                return Ok(await assignmentRepository.GetAssignmentsByEvent(eventId));
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get assignments by event");
            }
        }

        [HttpPost]

        public async Task<IActionResult> AddAssignment(Assignment assignment)
        {
            try
            {
                await assignmentRepository.InsertAsync(assignment);
                await assignmentRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to add assignment");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(Assignment assignment)
        {
            try
            {
                await assignmentRepository.UpdateAsync(assignment);
                await assignmentRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to update assignment");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            try
            {
                await assignmentRepository.DeleteAsync(assignmentId);
                await assignmentRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to delete assignment");
            }
        }
    }
}
