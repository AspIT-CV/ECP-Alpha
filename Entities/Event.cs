using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Event
    {
        public Event()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int EventId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Address { get; set; } = null!;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrganizerIdFk { get; set; }

        public virtual User OrganizerIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
