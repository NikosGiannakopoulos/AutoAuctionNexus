using Microsoft.Extensions.DependencyInjection;
using Search_Service.Application.Services.Interfaces;
using Search_Service.Application.Services.Implementations;

namespace Search_Service.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();

            return services;
        }
    }
}