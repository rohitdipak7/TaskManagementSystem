using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly TaskDbContext _context;

        public ReportRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsDueInNextDaysAsync(int days)
        {
            var dueDateThreshold = DateTime.Now.AddDays(days);
            return await _context.Tickets
                .Where(t => t.DueDate <= dueDateThreshold && t.Status != TicketStatus.Done)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetCompletedTicketsInDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Tickets
                .Where(t => t.Status == TicketStatus.Done && t.ModifiedDate >= startDate && t.ModifiedDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeamPerformance>> GetTeamPerformanceAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Tickets
                .Where(t => t.ModifiedDate >= startDate && t.ModifiedDate <= endDate && t.Status == TicketStatus.Done)
                .Include(t => t.User)
                .ThenInclude(u => u.Team)
                .GroupBy(t => new { t.User.Team.ID, t.User.Team.Name })
                .Select(g => new TeamPerformance
                {
                    TeamID = g.Key.ID,
                    TeamName = g.Key.Name,
                    CompletedTasks = g.Count()
                })
                .ToListAsync();


        }
    }
}
