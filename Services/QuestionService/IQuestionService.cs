using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum_app.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<ServiceResponse<List<GetQuestionDto>>> GetAll();
        Task<ServiceResponse<GetQuestionDto>> GetSingle(int id);
        Task<ServiceResponse<List<GetQuestionDto>>> AddQuestion(AddQuestionDto newQuestion);
        Task<ServiceResponse<GetQuestionDto>> UpdateQuestion(int id, AddQuestionDto updatedQuestion);
        Task<ServiceResponse<List<GetQuestionDto>>> DeleteQuestion(int id);
    }
}