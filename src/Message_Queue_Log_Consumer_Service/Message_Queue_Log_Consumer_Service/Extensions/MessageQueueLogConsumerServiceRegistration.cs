using MassTransit;
using Microsoft.EntityFrameworkCore;
using Message_Queue_Log_Consumer_Service.Data;
using Microsoft.Extensions.DependencyInjection;
using Message_Queue_Log_Consumer_Service.Services;

namespace Message_Queue_Log_Consumer_Service.Extensions
{
    public static class MessageQueueLogConsumerServiceRegistration
    {
        public static IServiceCollection AddMessageQueueLoggerConsumerServices(this IServiceCollection services, string connectionString, string rabbitMqHost)
        {
            services.AddDbContext<LogDbContext>(options => options.UseNpgsql(connectionString));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<LogMessageConsumer>();

                x.UsingRabbitMq((context, configure) =>
                {
                    configure.Host(rabbitMqHost);
                    configure.ReceiveEndpoint("message-queue-logs", e =>
                    {
                        e.ConfigureConsumer<LogMessageConsumer>(context);
                    });
                });
            });

            return services;
        }
    }
}