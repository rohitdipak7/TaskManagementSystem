using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TaskDbContext _context;

        public TicketRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets
                .Include(t => t.Documents)
                .Include(t => t.Notes)
                .ToListAsync();
        }

        public async Task<Ticket?> GetTicketByIdAsync(Guid id)
        {
            return await _context.Tickets
                .Include(t => t.Documents)
                .Include(t => t.Notes)
                .FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                if (ticket.Documents != null)
                    _context.Documents.RemoveRange(ticket.Documents);
                if (ticket.Notes != null)
                    _context.Notes.RemoveRange(ticket.Notes);
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Document>> GetDocumentsByTicketIdAsync(Guid ticketId)
        {
            return await _context.Documents.Where(d => d.TicketID == ticketId).ToListAsync();
        }

        public async Task AddDocumentAsync(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(Guid ticketId, Guid documentId)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.TicketID == ticketId && d.ID == documentId);
            if (document != null)
            {
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Note>> GetNotesByTicketIdAsync(Guid ticketId)
        {
            return await _context.Notes.Where(n => n.TicketID == ticketId).ToListAsync();
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(Guid ticketId, Guid noteId)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.TicketID == ticketId && n.ID == noteId);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
    }
}
