using Domain;
using System.Collections.Generic;

namespace Logic.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        IEnumerable<User> GetUsers();
    }
}