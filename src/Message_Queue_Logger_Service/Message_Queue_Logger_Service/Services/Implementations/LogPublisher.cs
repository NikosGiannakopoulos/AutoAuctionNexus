using MassTransit;
using Message_Queue_Logger_Service.Entities;
using Message_Queue_Logger_Service.Services.Interfaces;

namespace Message_Queue_Logger_Service.Services.Implementations
{
    public class LogPublisher : ILogPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public LogPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish(LogMessage logMessage)
        {
            await _publishEndpoint.Publish(logMessage);
        }
    }
}