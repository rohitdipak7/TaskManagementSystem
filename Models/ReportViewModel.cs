namespace TaskManagementSystem.Models
{
    public class ReportViewModel
    {
        public List<Ticket> TicketsDueInNextWeek { get; set; }
        public List<Ticket> CompletedTickets { get; set; }
        public Dictionary<Guid, int> TeamPerformance { get; set; }
    }
    public class TeamPerformance
    {
        public Guid TeamID { get; set; }
        public Team Team { get; set; }
        public string TeamName { get; set; }
        public int CompletedTasks { get; set; }
    }

}
