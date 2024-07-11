using Auction_Service.Infrastructure.Data;
using Auction_Service.Application.Extensions;
using Auction_Service.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider.GetService<AuctionDbContext>();
    AuctionDbInitializer.InitDb(serviceProvider);
}

app.Run();