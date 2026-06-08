using LogBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogBookServices.Interfaces
{
    public interface ILogSessionService
    {
        Task<IEnumerable<LogSession>> GetAllAsync(string? sessionID, string? sessionDate, string? durationMinutes, string? sessionDescription);

        Task<LogSession?> GetByIdAsync(int id);

        Task<LogSession> CreateAsync(LogSession logSession);

        Task<bool> UpdateAsync(int id, LogSession updatedLogSession);

        Task<bool> DeleteAsync(int id);
    }
}