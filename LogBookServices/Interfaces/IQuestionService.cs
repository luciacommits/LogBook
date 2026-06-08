using LogBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogBookServices.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync(string? questionID, string? questionStatement, string? questionDate, string? answerDate, string? answer);

        Task<Question?> GetByIdAsync(int id);

        Task<Question> CreateAsync(Question question);

        Task<bool> UpdateAsync(int id, Question updatedQuestion);

        Task<bool> DeleteAsync(int id);
    }
}