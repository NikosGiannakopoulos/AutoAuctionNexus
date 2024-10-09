using Microsoft.Extensions.Options;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Search_Service.Infrastructure.Configuration;
using Search_Service.Domain.Repositories.Interfaces;
using Search_Service.Infrastructure.Repositories.Implementations;

namespace Search_Service.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ElasticSearchSettings>(configuration.GetSection("Elasticsearch"));

            services.AddSingleton(provider =>
            {
                var elasticSearchSettings = provider.GetRequiredService<IOptions<ElasticSearchSettings>>().Value;
                return new ElasticsearchClient(new ElasticsearchClientSettings(new Uri(elasticSearchSettings.Uri)));
            });

            services.AddScoped<ISearchRepository, SearchRepository>();

            return services;
        }
    }
}