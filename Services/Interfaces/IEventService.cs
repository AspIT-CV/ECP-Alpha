using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IEventService<TEntity> : IRestService<TEntity> where TEntity : class
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<List<Event>> GetEventsByOrganiserAsync(int organiserId);
    }
}
