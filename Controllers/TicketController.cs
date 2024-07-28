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

        // Endpoints for managing documents
        [HttpGet("{ticketId}/documents")]
        public async Task<IActionResult> GetDocuments(Guid ticketId)
        {
            var documents = await _ticketService.GetDocumentsByTicketIdAsync(ticketId);
            return Ok(documents);
        }

        [HttpPost("{ticketId}/documents")]
        public async Task<IActionResult> AddDocument(Guid ticketId, [FromBody] Document document)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            document.TicketID = ticketId;
            await _ticketService.AddDocumentAsync(document);
            return Ok(document);
        }

        [HttpDelete("{ticketId}/documents/{documentId}")]
        public async Task<IActionResult> DeleteDocument(Guid ticketId, Guid documentId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.DeleteDocumentAsync(ticketId, documentId);
            return Ok(true);
        }

        // Endpoints for managing notes
        [HttpGet("{ticketId}/notes")]
        public async Task<IActionResult> GetNotes(Guid ticketId)
        {
            var notes = await _ticketService.GetNotesByTicketIdAsync(ticketId);
            return Ok(notes);
        }

        [HttpPost("{ticketId}/notes")]
        public async Task<IActionResult> AddNote(Guid ticketId, [FromBody] Note note)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            note.TicketID = ticketId;
            await _ticketService.AddNoteAsync(note);
            return Ok(note);
        }

        [HttpDelete("{ticketId}/notes/{noteId}")]
        public async Task<IActionResult> DeleteNote(Guid ticketId, Guid noteId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.DeleteNoteAsync(ticketId, noteId);
            return Ok(true);
        }

    }

}
