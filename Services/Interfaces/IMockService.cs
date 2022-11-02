using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IMockService
    {
        EcpContext Context { get; }
        List<Event> Events { get; }
    }
}
