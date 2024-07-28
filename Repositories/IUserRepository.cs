using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User User);
        Task UpdateUserAsync(User User);
        Task DeleteUserAsync(Guid id);
        Task<bool> ValidateUserCredentialsAsync(Login login);

    }
}

