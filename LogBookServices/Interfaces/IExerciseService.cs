using LogBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogBookServices.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllAsync(string? exerciseID, string? exerciseDescription, string? result);

        Task<Exercise?> GetByIdAsync(int id);

        Task<Exercise> CreateAsync(Exercise exercise);

        Task<bool> UpdateAsync(int id, Exercise updatedExercise);

        Task<bool> DeleteAsync(int id);
    }
}