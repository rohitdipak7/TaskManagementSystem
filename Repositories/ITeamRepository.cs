using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(Guid id);
        Task AddTeamAsync(Team Team);
        Task UpdateTeamAsync(Team Team);
        Task DeleteTeamAsync(Guid id);
    }
}

