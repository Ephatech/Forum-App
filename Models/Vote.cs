using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace forum_app.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public int UserID { get; set; }
        public int? QuestionID { get; set; } // Nullable if the vote is for an answer
        public int? AnswerID { get; set; }   // Nullable if the vote is for a question
        public VoteType Type { get; set; } = VoteType.Upvote; // "Upvote" or "Downvote"


        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("QuestionID")]
        public Question Question { get; set; }
        
        [ForeignKey("AnswerID")]
        public Answer Answer { get; set; }
    }
}