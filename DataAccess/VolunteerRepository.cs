namespace DataAccess
{
	public class VolunteerRepository : GenericRepository<AssignmentVolunteer>
	{
		public VolunteerRepository(EcpContext context) : base(context)
		{

		}


		public async Task<IEnumerable<Assignment>> GetAssignmentsFromVolunteerAndEvent(int volunteerID, int eventID)
		{
			return await dbSet.Where(s => s.UserId == volunteerID && s.Assignment.EventIdFk == eventID).Select(s => s.Assignment).ToListAsync();
		}

		public async Task<IEnumerable<AssignmentVolunteer>> GetVolunteersByAssignmentAndEvent(int assignmentId, int eventId)
		{
			return await dbSet.Where(s => s.AssignmentId == assignmentId && s.Assignment.EventIdFk == eventId).ToListAsync();
		}

		public async Task<IEnumerable<AssignmentVolunteer>> GetVolunteersByAssignment(int assignmentId)
		{
			return await dbSet.Where(s => s.AssignmentId == assignmentId).ToListAsync();
		}

		public async Task SelectVolunteerToAssignment(int volunteerId, int assignmentId)
		{
			var volunteer = await dbSet.SingleAsync(s => s.UserId == volunteerId && s.AssignmentId == assignmentId);
			volunteer.IsSelected = true;
			await UpdateAsync(volunteer);
		}
	}
}
