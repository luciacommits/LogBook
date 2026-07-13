using LogBook.Data;
using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBookServices.Services
{
    public class LogUserService : ILogUserService

    {
        private readonly LogBookDBContext _context;

        public LogUserService(LogBookDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LogUser>> GetAllAsync(string? userID, string? email, string? userName, string Pass)
        {
            var logUsers = await _context.LogUsers.ToListAsync();

            if (!string.IsNullOrEmpty(userID))
            {
                logUsers = logUsers.Where(lu => lu.UserID.ToString().Contains(userID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(email))
            {
                logUsers = logUsers.Where(lu => lu.Email.ToString().Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(userName))
            {
                logUsers = logUsers.Where(lu => lu.UserName.ToString().Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(Pass))
            {
                logUsers = logUsers.Where(lu => lu.Pass.ToString().Contains(Pass, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return logUsers;
        }

        public async Task<LogUser?> GetByIdAsync(int id)
        {
            return await _context.LogUsers.FindAsync(id);
        }

        public async Task<LogUser> CreateAsync(LogUser logUser)
        {
            _context.LogUsers.Add(logUser);
            await _context.SaveChangesAsync();
            return logUser;
        }

        public async Task<bool> UpdateAsync(int id, LogUser updatedLogUser)
        {
            if (id != updatedLogUser.UserID)
            {
                return false;
            }

            _context.Entry(updatedLogUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var logUser = await _context.LogUsers.FindAsync(id);
            if (logUser == null)
            {
                return false;
            }

            _context.LogUsers.Remove(logUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}