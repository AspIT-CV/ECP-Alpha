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
            var returnResponse = new List<Assignment>();
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/api/Assignment/{eventId}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();

                    var deserilizeResponse = JsonConvert.DeserializeObject<MainResponseService>(response);

                    if (deserilizeResponse.IsSuccess)
                    {
                        returnResponse = JsonConvert.DeserializeObject<List<Assignment>>(deserilizeResponse.Content.ToString());
                    }
                }
                return returnResponse;
            }
        }
    }
}
