using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; } = "Here is my answer";

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("QuestionID")]
        public Question Question { get; set; }


        public List<Vote> Votes { get; set; }
    }
}