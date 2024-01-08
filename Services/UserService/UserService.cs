using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;

namespace forum_app.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User(),

            new User {UserId = 1, Username = "Abebe", Password = "Abebe123"},

            new User {UserId = 2, Username = "Kebede", Password = "Kebede123"}
        };

        public async Task<ServiceResponse<List<User>>> AddUser(User newUser)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            users.Add(newUser);
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = users;
            return serviceResponse;
         }

        public async Task<ServiceResponse<User>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = users.FirstOrDefault(u => u.UserId == id);
            serviceResponse.Data = user;
            return serviceResponse;      
        }
    }
}