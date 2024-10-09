using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Auction_Service.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Auction_Service.Domain.Repositories.Interfaces;
using Auction_Service.Infrastructure.Repositories.Implementations;

namespace Auction_Service.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuctionDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("AuctionsConnection")));
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            return services;
        }
    }
}