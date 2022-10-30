using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Assignment
    {
        public int AssignmentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int VolunteersRequested { get; set; }
        public int EventIdFk { get; set; }

        public virtual Event EventIdFkNavigation { get; set; } = null!;
    }
}
