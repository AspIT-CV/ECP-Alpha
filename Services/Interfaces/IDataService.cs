using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IDataService
    {
        Task<ObservableCollection<Event>> GetAllEventsAsync();
    }
}
