using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
