using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = "Ephrem";
        public string Password { get; set; } = "ephrem123";
        
        
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }  
        public List<Vote> Votes { get; set; }      
    }
}