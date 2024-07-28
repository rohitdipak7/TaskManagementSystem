using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketService;

        public TicketController(ITicketRepository ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(Guid id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.AddTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.ID }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.UpdateTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.ID }, ticket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.DeleteTicketAsync(id);
            return Ok(true);
        }

        // Additional endpoints for updating, deleting, and managing tickets
    }

}
