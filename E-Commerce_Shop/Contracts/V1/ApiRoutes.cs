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
            public const string AddUser = Base + "/users";
            public const string GetUserByID = Base + "/users/{userId}";
        }
    }
}
