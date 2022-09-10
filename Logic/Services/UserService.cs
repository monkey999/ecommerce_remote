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

        public async Task<bool> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            var created = await _userRepository.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.FindAll()
                            .OrderBy(u => u.Name)
                                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.FindByCondition(u => u.Id.Equals(id))
                            .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            var updated = await _userRepository.SaveChangesAsyncWithResult();

            return updated > 0;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            _userRepository.RemoveById(userId);
            var deleted = await _userRepository.SaveChangesAsyncWithResult();

            return deleted > 0;
        }
    }
}
