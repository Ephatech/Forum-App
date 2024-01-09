using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.DTOs.User
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "Ephrem";
        public string Password { get; set; } = "ephrem123";
    }
}