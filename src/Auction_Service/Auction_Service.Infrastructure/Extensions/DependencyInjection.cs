using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Auction_Service.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Auction_Service.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuctionDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}