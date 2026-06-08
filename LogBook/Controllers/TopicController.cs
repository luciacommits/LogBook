using Microsoft.AspNetCore.Mvc;
using LogBook.Models;
using LogBookServices.Interfaces;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAll([FromQuery] string? TopicID = null, [FromQuery] string? Theme = null, [FromQuery] string? Content = null)
        {
            var topics = await _topicService.GetAllAsync(TopicID, Theme, Content);
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetById(int id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            return topic is null ? NotFound() : Ok(topic);
        }

        [HttpPost]
        public async Task<ActionResult<Topic>> Create(Topic topic)
        {
            var createdTopic = await _topicService.CreateAsync(topic);
            return CreatedAtAction(nameof(GetById), new { id = createdTopic.TopicID }, createdTopic);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Topic updatedTopic)
        {
            var result = await _topicService.UpdateAsync(id, updatedTopic);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _topicService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
