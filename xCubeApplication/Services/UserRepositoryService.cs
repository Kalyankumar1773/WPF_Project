

using Microsoft.EntityFrameworkCore;
using xCubeApplication.ClientDAL;
using xCubeApplication.Models;

namespace xCubeApplication.Services
{
    public class UserRepositoryService : IUserRepositoryService
    {
        private readonly ApplicationDbContext _context;
        public UserRepositoryService()
        {
            _context = new ApplicationDbContext();
        }
        public UserRepositoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserDetails> GetUserByNameAsync(string Name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == Name);
        }

        // Get all users
        public async Task<IEnumerable<UserDetails>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get a specific user by ID
        public async Task<UserDetails> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Add a new user
        public async Task AddUserAsync(UserDetails user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Update an existing user
        public async Task UpdateUserAsync(UserDetails user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Delete a user by ID
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
