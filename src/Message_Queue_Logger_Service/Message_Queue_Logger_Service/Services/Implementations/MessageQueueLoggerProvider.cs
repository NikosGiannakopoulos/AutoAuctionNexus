using Microsoft.Extensions.Logging;

namespace Message_Queue_Logger_Service.Services.Implementations
{
    public class MessageQueueLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public MessageQueueLoggerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MessageQueueLogger(categoryName, _serviceProvider);
        }

        public void Dispose() { }
    }
}