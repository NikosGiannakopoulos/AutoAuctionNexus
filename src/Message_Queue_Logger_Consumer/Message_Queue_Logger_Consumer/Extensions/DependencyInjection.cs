using MassTransit;
using Microsoft.EntityFrameworkCore;
using Message_Queue_Logger_Consumer.Data;
using Message_Queue_Logger_Consumer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Message_Queue_Logger_Consumer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMessageQueueLoggerConsumerServices(this IServiceCollection services, string connectionString, string rabbitMqHost)
        {
            services.AddDbContext<LogDbContext>(options => options.UseSqlServer(connectionString));

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