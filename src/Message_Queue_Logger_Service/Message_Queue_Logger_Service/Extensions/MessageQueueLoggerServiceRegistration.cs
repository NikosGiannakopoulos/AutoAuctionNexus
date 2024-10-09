using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Message_Queue_Logger_Service.Services.Interfaces;
using Message_Queue_Logger_Service.Services.Implementations;

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

            services.AddScoped<ILogPublisher, LogPublisher>();
            services.AddSingleton<ILoggerProvider, MessageQueueLoggerProvider>();

            return services;
        }
    }
}