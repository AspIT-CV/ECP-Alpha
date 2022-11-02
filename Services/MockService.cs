using Entities;
using Services.Interfaces;

namespace Services
{
    public class MockService : IMockService
    {
        private EcpContext context = new();
        private List<Event> events = new List<Event>();

        public EcpContext Context { get {return context; } }
        public List<Event> Events
        {
            get
            {
                if (events == null)
                    events = context.Events.ToList();
                return events;
            }
        }

    }
}