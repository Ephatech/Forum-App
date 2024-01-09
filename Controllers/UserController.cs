using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;
using forum_app.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using forum_app.DTOs;

namespace forum_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAll(){
            return Ok( await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingle(int id){
            return Ok( await _userService.GetSingle(id));
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(AddUserDto newUser){
            
            return Ok( await _userService.AddUser(newUser));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(int id, AddUserDto updatedUser){

            var response = await _userService.UpdateUser(id, updatedUser);
            if(response is  null){
                return NotFound(response);
            }else{
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> DeleteUser(int id){
            var response = await _userService.DeleteUser(id);
            if(response is  null){
                return NotFound(response);
            }else{
                return Ok(response);
            }
        }

    }
}