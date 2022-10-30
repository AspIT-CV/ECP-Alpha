using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class AssignmentVolunteer
    {
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
        public bool IsSelected { get; set; }

        public virtual Assignment Assignment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
