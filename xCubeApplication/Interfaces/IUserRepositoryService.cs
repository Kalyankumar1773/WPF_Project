using xCubeApplication.Models;

namespace xCubeApplication.Interfaces
{
    public interface IUserRepositoryService
    {
        Task<IEnumerable<UserDetails>> GetAllUsersAsync();
        Task<UserDetails> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDetails user);
        Task UpdateUserAsync(UserDetails user);
        Task DeleteUserAsync(int id);
    }
}
