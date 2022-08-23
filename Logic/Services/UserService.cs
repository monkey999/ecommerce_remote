﻿using DataAccess;
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


        public void CreateUser(User user) => _userRepository.Add(user);

        public IEnumerable<User> GetUsers() => _userRepository.FindAll();

    }
}