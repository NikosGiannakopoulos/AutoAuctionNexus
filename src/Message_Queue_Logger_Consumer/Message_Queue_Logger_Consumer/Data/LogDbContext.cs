using Microsoft.EntityFrameworkCore;
using Message_Queue_Logger_Consumer.Entities;

namespace Message_Queue_Logger_Consumer.Data
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }

        public DbSet<LogMessage> LogMessages { get; set; }
    }
}