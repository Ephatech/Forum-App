using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        // public int UserID { get; set; }
        public string Title { get; set; } = "My Question";
        public string Content { get; set; } = "Here is my question";

        // [ForeignKey("UserID")]
        // public User User { get; set; }


        // public List<Answer> Answers { get; set; }
        // public List<Vote> Votes { get; set; }
    }
}