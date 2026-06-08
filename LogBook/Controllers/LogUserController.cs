using Microsoft.AspNetCore.Mvc;
using LogBook.Models;
using LogBookServices.Interfaces;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogUserController : ControllerBase
    {
        private readonly ILogUserService _logUserService;

        public LogUserController(ILogUserService logUserService)
        {
            _logUserService = logUserService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogUser>>> GetAll([FromQuery] string? UserID = null, [FromQuery] string? Email = null, [FromQuery] string? UserName = null)
        {
            var logUsers = await _logUserService.GetAllAsync(UserID, Email, UserName);
            return Ok(logUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogUser>> GetById(int id)
        {
            var logUser = await _logUserService.GetByIdAsync(id);
            return logUser is null ? NotFound() : Ok(logUser);
        }

        [HttpPost]
        public async Task<ActionResult<LogUser>> Create(LogUser logUser)
        {
            var createdLogUser = await _logUserService.CreateAsync(logUser);
            return CreatedAtAction(nameof(GetById), new { id = createdLogUser.UserID}, createdLogUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LogUser updatedLogUser)
        {
            var result = await _logUserService.UpdateAsync(id, updatedLogUser);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _logUserService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
