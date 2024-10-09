using Microsoft.Extensions.Logging;
using Message_Queue_Logger_Service.Entities;
using Microsoft.Extensions.DependencyInjection;
using Message_Queue_Logger_Service.Services.Interfaces;

namespace Message_Queue_Logger_Service.Services.Implementations
{
    public class MessageQueueLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly IServiceProvider _serviceProvider;

        public MessageQueueLogger(string categoryName, IServiceProvider serviceProvider)
        {
            _categoryName = categoryName;
            _serviceProvider = serviceProvider;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            using var scope = _serviceProvider.CreateScope();
            var logPublisher = scope.ServiceProvider.GetRequiredService<ILogPublisher>();

            var logMessage = new LogMessage
            {
                Source = _categoryName,
                Level = logLevel.ToString(),
                Message = formatter(state, exception),
                Exception = exception.ToString(),
                Timestamp = DateTime.UtcNow
            };

            logPublisher.Publish(logMessage);
        }
    }
}