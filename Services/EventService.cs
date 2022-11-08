using Entities;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EventService : RestService<Event>, IEventService<Event>
    {

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await DoHttpGetRequest("Event");
        }

        public async Task<List<Event>> GetEventsByOrganiserAsync(int organiserId)
        {
            return await DoHttpGetRequest($"Event/{organiserId}");
        }
    }
}
