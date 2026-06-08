using LogBook.Models;

namespace LogBookServices.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetAllAsync(string? topicID, string? theme, string? content);

        Task<Topic?> GetByIdAsync(int id);

        Task<Topic> CreateAsync(Topic topic);

        Task<bool> UpdateAsync(int id, Topic updatedTopic);

        Task<bool> DeleteAsync(int id);
    }
}