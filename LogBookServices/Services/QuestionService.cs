using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using LogBook.Data;

namespace LogBookServices.Services
{
    public class QuestionService : IQuestionService

    {
        private readonly LogBookDBContext _context;

        public QuestionService(LogBookDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAllAsync(string? questionID, string? questionStatement, string? questionDate, string? answerDate, string? answer)
        {
            var questions = await _context.Questions.ToListAsync();

            if (!string.IsNullOrEmpty(questionID))
            {
                questions = questions.Where(t => t.QuestionID.ToString().Contains(questionID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(questionStatement))
            {
                questions = questions.Where(t => t.QuestionStatement.Contains(questionStatement, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(questionDate))
            {
                questions = questions.Where(t => t.QuestionDate.ToString().Contains(questionDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(answerDate))
            {
                questions = questions.Where(t => t.AnswerDate.ToString().Contains(answerDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(answer))
            {
                questions = questions.Where(t => t.Answer.Contains(answer, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return questions;
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question> CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> UpdateAsync(int id, Question updatedQuestion)
        {
            if (id != updatedQuestion.QuestionID)
            {
                return false;
            }

            _context.Entry(updatedQuestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return false;
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}