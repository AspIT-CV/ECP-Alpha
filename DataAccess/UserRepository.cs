using Entities;

namespace DataAccess
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(EcpContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetEventsSeekingVolunteers()
        {
            var y = await context.Events.Where(s => s.Assignments.Any(s => s.VolunteersRequested - context.AssignmentVolunteers.Where(t => t.AssignmentId == s.AssignmentId).Count() > 0)).ToListAsync();
            return y;
        }

        public async Task<IEnumerable<Event>> GetEventsUserHasDone(int userId)
        {
            throw new NotImplementedException();
            // Not finished
            //var y = await context.Events
            //    .SelectMany(@event => @event.Assignments, (Event @event, List<Assignment> assignments) => new
            //    {
            //        @event,
            //        assignments
            //    })
            //    .Where(eAndA => context.AssignmentVolunteers.Where(s => s.UserId == userId).Select(s => s.AssignmentId).Contains(eAndA.assignments.AssignmentId))
            //    .Select(s => new
            //    {
            //        Event = s.@event,
            //        Assignments = s.assignments
            //    })
            //    .ToListAsync();
            //return
        }
    }
}
