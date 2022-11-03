namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<Assignment>
    {
        public AssignmentRepository(EcpContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByEvent(int eventId)
        {
            return await dbSet.Where(s => s.EventIdFk == eventId).ToListAsync();
        }
    }
}
