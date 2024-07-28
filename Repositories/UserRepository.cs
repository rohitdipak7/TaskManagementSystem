using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext _context;

        public UserRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddUserAsync(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ValidateUserCredentialsAsync(Login login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Username == login.Username);
            if (user == null)
                return false;
            return HashPassword(login.Password) == user.PasswordHash? true:false;
        }
        private string HashPassword(string password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(password);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }


    }
}
