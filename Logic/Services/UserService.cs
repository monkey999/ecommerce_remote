using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.FindAll();
        }
        public IEnumerable<User> GetUserById(int id)
        {
            return _userRepository.FindByCondition(x=>x.Id.Equals(id));
        }
    }
}
