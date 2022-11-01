using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventRepository : GenericRepository<Event>
    {
        public EventRepository(EcpContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetEventsByOrganizerAsync(int organizerId)
        {
            return await dbSet.Where(s => s.OrganizerIdFk == organizerId).ToListAsync();
        }
    }
}
