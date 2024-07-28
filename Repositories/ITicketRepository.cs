using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(Guid id);
        Task<IEnumerable<Document>> GetDocumentsByTicketIdAsync(Guid ticketId);
        Task AddDocumentAsync(Document document);
        Task DeleteDocumentAsync(Guid ticketId, Guid documentId);
        Task<IEnumerable<Note>> GetNotesByTicketIdAsync(Guid ticketId);
        Task AddNoteAsync(Note note);
        Task DeleteNoteAsync(Guid ticketId, Guid noteId);

    }
}

