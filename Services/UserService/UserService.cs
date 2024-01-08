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

        public async Task<ServiceResponse<User>> UpdateUser(int id, User updatedUser)
        {
            var serviceResponse = new ServiceResponse<User>();

            try
            {
                var existingUser = users.FirstOrDefault(u => u.UserId == id);

                if (existingUser == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found";
                    return serviceResponse;
                }

                // Update properties of the existing user with the values from updatedUser
                existingUser.Username = updatedUser.Username;
                existingUser.Password = updatedUser.Password;
                // Update other properties as needed

                // You may want to perform additional validation or business logic here

                serviceResponse.Data = existingUser;
                serviceResponse.Message = "User updated successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<User>();

            try
            {
                var userToRemove = users.FirstOrDefault(u => u.UserId == id);

                if (userToRemove == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found";
                    return serviceResponse;
                }

                // Perform any additional logic before or after removing the user

                users.Remove(userToRemove);

                serviceResponse.Message = "User deleted successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred: {ex.Message}";
            }

            return serviceResponse;
        }


    }
}