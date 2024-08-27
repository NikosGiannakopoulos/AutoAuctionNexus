using MassTransit;
using Microsoft.Extensions.Logging;

namespace Message_Queue_Logger_Service
{
    public class MessageQueueLoggerProvider : ILoggerProvider
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessageQueueLoggerProvider(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MessageQueueLogger(categoryName, _publishEndpoint);
        }

        public void Dispose() { }
    }
}