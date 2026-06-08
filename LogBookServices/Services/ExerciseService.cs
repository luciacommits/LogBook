using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using LogBook.Data;

namespace LogBookServices.Services
{
    public class ExerciseService : IExerciseService

    {
        private readonly LogBookDBContext _context;

        public ExerciseService(LogBookDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Exercise>> GetAllAsync(string? exerciseID, string? exerciseDescription, string? result)
        {
            var exercises = await _context.Exercises.ToListAsync();

            if (!string.IsNullOrEmpty(exerciseID))
            {
                exercises = exercises.Where(t => t.ExerciseID.ToString().Contains(exerciseID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(exerciseDescription))
            {
                exercises = exercises.Where(t => t.ExerciseDescription.Contains(exerciseDescription, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(result))
            {
                exercises = exercises.Where(t => t.Result.Contains(result, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return exercises;
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> CreateAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<bool> UpdateAsync(int id, Exercise updatedExercise)
        {
            if (id != updatedExercise.ExerciseID)
            {
                return false;
            }

            _context.Entry(updatedExercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return false;
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}