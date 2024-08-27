using Microsoft.EntityFrameworkCore;
using Message_Queue_Log_Consumer_Service.Entities;

namespace Message_Queue_Log_Consumer_Service.Data
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }

        public DbSet<LogMessage> LogMessages { get; set; }
    }
}