using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using LogBook.Data;

namespace LogBookServices.Services
{
    public class TopicService : ITopicService

    {
        private readonly LogBookDBContext _context;

        public TopicService(LogBookDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Topic>> GetAllAsync(string? topicID, string? theme, string? content)
        {
            var topics = await _context.Topics.ToListAsync();

            if (!string.IsNullOrEmpty(topicID))
            {
                topics = topics.Where(t => t.TopicID.ToString().Contains(topicID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(theme))
            {
                topics = topics.Where(t => t.Theme.Contains(theme, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(content))
            {
                topics = topics.Where(t => t.Content.Contains(content, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return topics;
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _context.Topics.FindAsync(id);
        }

        public async Task<Topic> CreateAsync(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> UpdateAsync(int id, Topic updatedTopic)
        {
            if (id != updatedTopic.TopicID)
            {
                return false;
            }

            _context.Entry(updatedTopic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return false;
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}