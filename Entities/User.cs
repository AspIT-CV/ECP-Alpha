namespace Entities
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}