using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_app.Models;
using forum_app.Services.QuestionService;
using Microsoft.AspNetCore.Mvc;
using forum_app.DTOs;


namespace forum_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        public IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetQuestionDto>>>> GetAll(){
            return Ok( await _questionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuestionDto>>> GetSingle(int id){
            return Ok( await _questionService.GetSingle(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetQuestionDto>>>> AddQuestion(AddQuestionDto newQuestion){    
            return Ok( await _questionService.AddQuestion(newQuestion));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuestionDto>>> UpdateQuestion(int id, AddQuestionDto updatedQuestion){

            var response = await _questionService.UpdateQuestion(id, updatedQuestion);
            if(response is  null){
                return NotFound(response);
            }else{
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetQuestionDto>>>> DeleteQuestion(int id){
            var response = await _questionService.DeleteQuestion(id);
            if(response is  null){
                return NotFound(response);
            }else{
                return Ok(response);
            }
        }
        
    }
}