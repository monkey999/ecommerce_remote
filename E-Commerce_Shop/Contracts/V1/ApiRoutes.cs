using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Users
        {
            public const string GetAllUsers = Base + "/users";
            //public static readonly string GetUserById = $"{Base}/{userId}";
            //public static readonly string AddUser = $"{Base}/users";
            //public static readonly string UpdateUser = $"{Base}/users";
        }
    }
}
