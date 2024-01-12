global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;

namespace forum_app.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private static List<Question> questions = new List<Question>{
            new Question(),

            new Question {QuestionId = 1, Title = "ASP.Net", Content = "What is ASP.Net?"},

            new Question {QuestionId = 2, Title = "C#", Content = "What is C#?"}
        };

        private readonly IMapper _mapper;

        public QuestionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetQuestionDto>>> AddQuestion(AddQuestionDto newQuestion)
        {
            var serviceResponse = new ServiceResponse<List<GetQuestionDto>>();
            var question = _mapper.Map<Question>(newQuestion);
            question.QuestionId = questions.Max(q => q.QuestionId) +1;
            questions.Add(question);
            serviceResponse.Data = questions.Select(q => _mapper.Map<GetQuestionDto>(q)).ToList();
            return serviceResponse;
        }

         public async Task<ServiceResponse<List<GetQuestionDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetQuestionDto>>();
            serviceResponse.Data = questions.Select(q => _mapper.Map<GetQuestionDto>(q)).ToList();
            return serviceResponse;
         }

         public async Task<ServiceResponse<GetQuestionDto>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();
            var question = questions.FirstOrDefault(q => q.QuestionId == id);
            serviceResponse.Data = _mapper.Map<GetQuestionDto>(question);
            return serviceResponse;      
        }
        
        public async Task<ServiceResponse<GetQuestionDto>> UpdateQuestion(int id, AddQuestionDto updatedQuestion)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();

            try
            {
                var existingQuestion = questions.FirstOrDefault(q => q.QuestionId == id);

                if (existingQuestion == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Question not found";
                    return serviceResponse;
                }

                // Update properties of the existing Quesion with the values from updatedQuesion
                existingQuestion.Title = updatedQuestion.Title;
                existingQuestion.Content = updatedQuestion.Content;
                // Update other properties as needed

                // You may want to perform additional validation or business logic here

                serviceResponse.Data = _mapper.Map<GetQuestionDto>(existingQuestion);
                serviceResponse.Message = "Question updated successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred: {ex.Message}";
            }

            return serviceResponse;
        }

         public async Task<ServiceResponse<List<GetQuestionDto>>> DeleteQuestion(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetQuestionDto>>();

            try
            {
                var questionToRemove = questions.FirstOrDefault(q => q.QuestionId == id);

                if (questionToRemove == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Question not found";
                    return serviceResponse;
                }

                // Perform any additional logic before or after removing the Quesion

                questions.Remove(questionToRemove);

                serviceResponse.Message = "Question deleted successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred: {ex.Message}";
            }

            return serviceResponse;
        }

    }
}