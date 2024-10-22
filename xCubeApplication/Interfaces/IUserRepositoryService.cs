using xCubeApplication.Models;

namespace xCubeApplication.Interfaces
{
    public interface IUserRepositoryService
    {
        List<UserDetails> GetAllUserDetails();
        bool AddUser(UserDetails user);
        bool UpdateUser(UserDetails user);
        UserDetails GetUserDetails(string name);
        Task<IEnumerable<UserDetails>> GetAllUsersAsync();
        Task<UserDetails> GetUserByNameAsync(string Name);
        Task<UserDetails> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDetails user);
        Task UpdateUserAsync(UserDetails user);
        Task DeleteUserAsync(int id);
    }
}
