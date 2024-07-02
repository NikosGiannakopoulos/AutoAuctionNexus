using Microsoft.Extensions.DependencyInjection;
using Auction_Service.Application.Services.Interfaces;
using Auction_Service.Application.Services.Implementations;

namespace Auction_Service.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuctionService, AuctionService>();
            return services;
        }
    }
}