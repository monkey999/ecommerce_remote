using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}