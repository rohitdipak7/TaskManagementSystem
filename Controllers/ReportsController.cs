using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportService;

        public ReportsController(IReportRepository reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("due-in-next/{days}")]
        public async Task<IActionResult> GetTicketsDueInNextDays(int days)
        {
            var tickets = await _reportService.GetTicketsDueInNextDaysAsync(days);
            return Ok(tickets);
        }

        [HttpGet("completed-tickets")]
        public async Task<IActionResult> GetCompletedTickets(DateTime startDate, DateTime endDate)
        {
            var tickets = await _reportService.GetCompletedTicketsInDateRangeAsync(startDate, endDate);
            return Ok(tickets);
        }

        [HttpGet("team-performance")]
        public async Task<IActionResult> GetTeamPerformance(DateTime startDate, DateTime endDate)
        {
            var performance = await _reportService.GetTeamPerformanceAsync(startDate, endDate);
            return Ok(performance);
        }
    }

}
