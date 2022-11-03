using Entities;
using Services.Interfaces;

namespace Services
{
    public class MockService : IDataService
    {
        public User User = new User()
        {
            Name = "William",
            UserId = 10,
            Description = "Mig"
        };

        public List<Assignment> Assignment = new()
        {
            new()
            {
                AssignmentId = 1,
                Name = "ToDo",
                Description = "To do list",
                StartTime = DateTime.Now,
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 2),
            }
        };

        
        public async Task<List<Event>> GetAllEventsAsync()
        {
            await Task.Delay(1000);
            return new()
            {
                new()
                {
                    Name = "LAN",
                    Description = "LAN arrangement",
                    EventId = 20,
                    Address = "AspIT - Storkøbenhavn",
                    StartTime = DateTime.Now,
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 5),
                    Organizer = User,
                    OrganizerIdFk = User.UserId,
                    Assignments = Assignment
                },
            };
        }

    }
}