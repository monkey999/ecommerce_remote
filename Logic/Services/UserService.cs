using DataAccess;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return await _userRepository.FindAll()
                            .OrderBy(u => u.Name)
                                .ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.FindByCondition(u => u.Id.Equals(id))
                            .SingleOrDefaultAsync();
        }
        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
