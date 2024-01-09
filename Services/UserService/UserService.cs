global using AutoMapper;
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

        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<User>(newUser);
            user.UserId = users.Max(u => u.UserId) +1;
            users.Add(user);
            serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return serviceResponse;
         }

        public async Task<ServiceResponse<GetUserDto>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = users.FirstOrDefault(u => u.UserId == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;      
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(int id, AddUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

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

                serviceResponse.Data = _mapper.Map<GetUserDto>(existingUser);
                serviceResponse.Message = "User updated successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

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