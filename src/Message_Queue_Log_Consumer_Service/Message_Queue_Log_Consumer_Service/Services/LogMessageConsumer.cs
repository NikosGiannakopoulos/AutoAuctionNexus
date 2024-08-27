using MassTransit;
using Message_Queue_Log_Consumer_Service.Data;
using Message_Queue_Log_Consumer_Service.Entities;

namespace Message_Queue_Log_Consumer_Service.Services
{
    public class LogMessageConsumer : IConsumer<LogMessage>
    {
        private readonly LogDbContext _dbContext;

        public LogMessageConsumer(LogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<LogMessage> context)
        {
            var logMessage = context.Message;
            await _dbContext.LogMessages.AddAsync(logMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}