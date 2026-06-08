using LogBook.Models;

namespace LogBookServices.Interfaces
{
    public interface ILogUserService
    {
        Task<IEnumerable<LogUser>> GetAllAsync(string? userID, string? email, string? userName);

        Task<LogUser?> GetByIdAsync(int id);

        Task<LogUser> CreateAsync(LogUser logUser);

        Task<bool> UpdateAsync(int id, LogUser updatedLogUser);

        Task<bool> DeleteAsync(int id);
    }
}