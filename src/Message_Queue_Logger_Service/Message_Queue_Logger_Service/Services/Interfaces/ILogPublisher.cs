using Message_Queue_Logger_Service.Entities;

namespace Message_Queue_Logger_Service.Services.Interfaces
{
    public interface ILogPublisher
    {
        Task Publish(LogMessage logMessage);
    }
}