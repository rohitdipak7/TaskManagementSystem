namespace TaskManagementSystem.Models
{
    public class Team
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
