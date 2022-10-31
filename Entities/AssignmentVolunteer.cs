namespace Entities
{
    public partial class AssignmentVolunteer
    {
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
        public bool IsSelected { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual User Volunteer { get; set; }
    }
}