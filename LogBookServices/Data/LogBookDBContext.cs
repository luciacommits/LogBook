using LogBook.Models;
using LogBookServices.Handlers;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Data
{
    public class LogBookDBContext(DbContextOptions<LogBookDBContext> options) : DbContext(options)
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<LogUser> LogUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<LogUser>().HasData(
                new LogUser
                {
                    UserID = 1,
                    Email = "admin@admin.com",
                    UserName = "admin",
                    Pass = PasswordHashHandler.HashPassword("admin")
                }
                );
        }
        public DbSet<LogSession> LogSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
