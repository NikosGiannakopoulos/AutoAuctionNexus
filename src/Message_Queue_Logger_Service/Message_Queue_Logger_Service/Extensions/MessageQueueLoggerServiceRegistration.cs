using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Message_Queue_Logger_Service.Extensions
{
    public static class MessageQueueLoggerServiceRegistration
    {
        public static IServiceCollection AddMessageQueueLoggerServices(this IServiceCollection services, string rabbitMqHost)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, configure) =>
                {
                    configure.Host(rabbitMqHost);
                });
            });

            services.AddSingleton<ILoggerProvider, MessageQueueLoggerProvider>();

            return services;
        }
    }
}