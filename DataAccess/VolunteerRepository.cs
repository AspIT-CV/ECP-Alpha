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
	}
}
