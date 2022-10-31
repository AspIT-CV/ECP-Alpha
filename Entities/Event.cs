namespace Entities
{
    public partial class Event
    {
        public Event()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrganizerIdFk { get; set; }

        public virtual User Organizer { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}