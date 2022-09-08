using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        void Update(User user);
    }
}