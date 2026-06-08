using Microsoft.AspNetCore.Mvc;
using LogBook.Models;
using LogBookServices.Interfaces;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogSessionController : ControllerBase
    {
        private readonly ILogSessionService _logSessionService;

        public LogSessionController(ILogSessionService logSessionService)
        {
            _logSessionService = logSessionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogSession>>> GetAll([FromQuery] string? SessionID = null, [FromQuery] string? SessionDate = null, [FromQuery] string? DurationMinutes = null, [FromQuery] string? SessionDescription = null)
        {
            var logSessions = await _logSessionService.GetAllAsync(SessionID, SessionDate, DurationMinutes, SessionDescription);
            return Ok(logSessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogSession>> GetById(int id)
        {
            var logSession = await _logSessionService.GetByIdAsync(id);
            return logSession is null ? NotFound() : Ok(logSession);
        }

        [HttpPost]
        public async Task<ActionResult<LogSession>> Create(LogSession logSession)
        {
            var createdLogSession = await _logSessionService.CreateAsync(logSession);
            return CreatedAtAction(nameof(GetById), new { id = createdLogSession.SessionID}, createdLogSession);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LogSession updatedLogSession)
        {
            var result = await _logSessionService.UpdateAsync(id, updatedLogSession);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _logSessionService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
