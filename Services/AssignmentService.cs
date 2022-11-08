using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Services.Interfaces;
using Newtonsoft.Json;

namespace Services
{
    public class AssignmentService : RestService<Assignment>, IAssignmentService
    {
        public async Task<List<Assignment>> GetAssignmentsByEventId(int eventId)
        {
            return await DoHttpGetRequest($"Assignment/{eventId}");
        }
    }
}
