namespace DataAccess
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(EcpContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetEventsSeekingVolunteers()
        {
            var y = await context.Events.Where(s => s.Assignments.Any(s => s.VolunteersRequested - context.AssignmentVolunteers.Where(t => t.AssignmentId == s.AssignmentId).Select(o => o.AssignmentId).Count() > 0)).ToListAsync();
            return y;
        }
    }
}
