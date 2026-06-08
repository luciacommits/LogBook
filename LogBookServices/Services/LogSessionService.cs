using LogBook.Models;
using LogBookServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using LogBook.Data;

namespace LogBookServices.Services
{
    public class LogSessionService : ILogSessionService

    {
        private readonly LogBookDBContext _context;

        public LogSessionService(LogBookDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LogSession>> GetAllAsync(string? sessionID, string? sessionDate, string? durationMinutes, string? sessionDescription)
        {
            var logSessions = await _context.LogSessions.ToListAsync();

            if (!string.IsNullOrEmpty(sessionID))
            {
                logSessions = logSessions.Where(ls => ls.SessionID.ToString().Contains(sessionID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(sessionDate))
            {
                logSessions = logSessions.Where(ls => ls.SessionDate.ToString().Contains(sessionDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(durationMinutes))
            {
                logSessions = logSessions.Where(ls => ls.DurationMinutes.ToString().Contains(durationMinutes, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(sessionDescription))
            {
                logSessions = logSessions.Where(ls => ls.SessionDescription.ToString().Contains(sessionDescription, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return logSessions;
        }

        public async Task<LogSession?> GetByIdAsync(int id)
        {
            return await _context.LogSessions.FindAsync(id);
        }

        public async Task<LogSession> CreateAsync(LogSession logSession)
        {
            _context.LogSessions.Add(logSession);
            await _context.SaveChangesAsync();
            return logSession;
        }

        public async Task<bool> UpdateAsync(int id, LogSession updatedLogSession)
        {
            if (id != updatedLogSession.SessionID)
            {
                return false;
            }

            _context.Entry(updatedLogSession).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var logSession = await _context.LogSessions.FindAsync(id);
            if (logSession == null)
            {
                return false;
            }

            _context.LogSessions.Remove(logSession);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}