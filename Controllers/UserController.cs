using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace forum_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>{
            new User(),

            new User {UserId = 1, Username = "Abebe", Password = "Abebe123"},

            new User {UserId = 2, Username = "Kebede", Password = "Kebede123"}
        };
        
        [HttpGet("GetAll")]
        public ActionResult<List<User>> GetAll(){
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetSingle(int id){
            return Ok(users.FirstOrDefault(u => u.UserId == id));
        }

        [HttpPost]

        public ActionResult<List<User>> AddUser(User newUser){
            users.Add(newUser);
            return Ok(users);
        }

    }
}