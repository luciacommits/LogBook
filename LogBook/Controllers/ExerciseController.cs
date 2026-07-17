using Microsoft.AspNetCore.Mvc;
using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAll([FromQuery] string? ExerciseID = null, [FromQuery] string? ExerciseDescription = null, [FromQuery] string? Result = null)
        {
            var exercises = await _exerciseService.GetAllAsync(ExerciseID, ExerciseDescription, Result);
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetById(int id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            return exercise is null ? NotFound() : Ok(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> Create(Exercise exercise)
        {
            var createdExercise = await _exerciseService.CreateAsync(exercise);
            return CreatedAtAction(nameof(GetById), new { id = createdExercise.ExerciseID}, createdExercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Exercise updatedExercise)
        {
            var result = await _exerciseService.UpdateAsync(id, updatedExercise);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _exerciseService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
