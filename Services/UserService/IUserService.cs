using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;

namespace forum_app.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAll();
        Task<ServiceResponse<User>> GetSingle(int id);
        Task<ServiceResponse<List<User>>> AddUser(User newUser);
    }
}