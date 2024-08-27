using MassTransit;
using Message_Queue_Logger_Consumer.Data;
using Message_Queue_Logger_Consumer.Entities;

namespace Message_Queue_Logger_Consumer.Services
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