using LogBook.Data;
using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll([FromQuery] string? QuestionID = null, [FromQuery] string? QuestionStatement = null, [FromQuery] string? QuestionDate = null, [FromQuery] string? AnswerDate = null, [FromQuery] string? Answer = null)
        {
            var questions = await _questionService.GetAllAsync(QuestionID, QuestionStatement, QuestionDate, AnswerDate, Answer);
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetById(int id)
        {
            var question = await _questionService.GetByIdAsync(id);
            return question is null ? NotFound() : Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Create(Question question)
        {
            var createdQuestion = await _questionService.CreateAsync(question);
            return CreatedAtAction(nameof(GetById), new { id = createdQuestion.QuestionID }, createdQuestion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Question updatedQuestion)
        {
            var result = await _questionService.UpdateAsync(id, updatedQuestion);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _questionService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}