using Message_Queue_Logger.Extensions;
using Auction_Service.Infrastructure.Data;
using Auction_Service.Application.Extensions;
using Auction_Service.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMessageQueueLoggerServices(builder.Configuration["RabbitMqHost"]);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuctionDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<AuctionDbInitializer>>();
    AuctionDbInitializer.InitDb(dbContext, logger);
}

app.Run();