using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsDueInNextDaysAsync(int days);
        Task<IEnumerable<Ticket>> GetCompletedTicketsInDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TeamPerformance>> GetTeamPerformanceAsync(DateTime startDate, DateTime endDate);

    }
}

