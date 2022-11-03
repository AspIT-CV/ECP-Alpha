using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        VolunteerRepository volunteerRepository = new(new());

        [HttpGet("AByVAndE/{volunteerId},{eventId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignmentsByVolunteerAndEvent(int volunteerId, int eventId)
        {
            try
            {
                return Ok(await volunteerRepository.GetAssignmentsFromVolunteerAndEvent(volunteerId, eventId));
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get assignments by volunteer and event");
            }
        }

        [HttpGet("VByAAndE/{assignmentId},{eventId}")]
        public async Task<ActionResult<IEnumerable<AssignmentVolunteer>>> GetVolunteersByAssignmentAndEvent(int assignmentId, int eventId)
        {
            try
            {
                return Ok(await volunteerRepository.GetVolunteersByAssignmentAndEvent(assignmentId, eventId));
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get volunteers by assignment and event");
            }
        }

        [HttpGet("VByA/{assignmentId}")]
        public async Task<ActionResult<IEnumerable<AssignmentVolunteer>>> GetVolunteersByAssignment(int assignmentId)
        {
            try
            {
                return Ok(await volunteerRepository.GetVolunteersByAssignment(assignmentId));
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occured attempting to get volunteers by assignment");
            }
        }

        [HttpPut("SelectVToA/{volunteerId},{assignmentId}")]
        public async Task<IActionResult> SelectVolunteerToAssignment(int volunteerId, int assignmentId)
        {
            try
            {
                await volunteerRepository.SelectVolunteerToAssignment(volunteerId, assignmentId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occured attempting to selecte volunteer to assignment\n{e}");
            }
        }
    }
}
