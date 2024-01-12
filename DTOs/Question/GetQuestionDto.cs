using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.DTOs.Question
{
    public class GetQuestionDto
    {
        public int QuestionID { get; set; }
        public string Title { get; set; } = "My Question";
        public string Content { get; set; } = "Here is my question";
    }
}