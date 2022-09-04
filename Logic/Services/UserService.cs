using DataAccess;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public IEnumerable<User> GetUserById(int id)
        {
            return _userRepository.FindByCondition(x => x.Id.Equals(id));
        }
        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
