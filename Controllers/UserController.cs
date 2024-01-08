using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;
using forum_app.Services.UserService;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAll(){
            return Ok( await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetSingle(int id){
            return Ok( await _userService.GetSingle(id));
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser(User newUser){
            
            return Ok( await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<User>>> UpdateUser(int id, User updatedUser){

            return Ok( await _userService.UpdateUser(id, updatedUser));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<User>>> DeleteUser(int id){
            return Ok( await _userService.DeleteUser(id));
        }

    }
}