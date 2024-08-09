using MassTransit;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Message_Queue_Logger
{
    public class MessageQueueLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly IPublishEndpoint _publishEndpoint;

        public MessageQueueLogger(string categoryName, IPublishEndpoint publishEndpoint)
        {
            _categoryName = categoryName;
            _publishEndpoint = publishEndpoint;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var logMessage = new LogMessage
            {
                Level = logLevel.ToString(),
                Message = formatter(state, exception),
                Exception = exception?.ToString(),
                Timestamp = DateTime.UtcNow
            };

            string jsonFormatLogMessage = JsonSerializer.Serialize(logMessage);

            _publishEndpoint.Publish(jsonFormatLogMessage);
        }
    }
}