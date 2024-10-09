using Microsoft.Extensions.Options;
using Elastic.Clients.Elasticsearch;
using Search_Service.Domain.Entities;
using Search_Service.Infrastructure.Configuration;
using Search_Service.Domain.Repositories.Interfaces;

namespace Search_Service.Infrastructure.Repositories.Implementations
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ElasticsearchClient _client;
        private readonly string _indexName;
        private static readonly string[] fields = ["Manufacturer", "Model", "Color"];

        public SearchRepository(ElasticsearchClient client, IOptions<ElasticSearchSettings> options)
        {
            _client = client;
            _indexName = options.Value.IndexName;
        }

        public async Task<IEnumerable<SearchDocument>> SearchAsync(string query)
        {
            var searchResponse = await _client.SearchAsync<SearchDocument>(s => s
                .Index(_indexName)
                .Query(q => q
                    .MultiMatch(m => m
                        .Fields(fields)
                        .Query(query)
                    )
                )
            );

            return searchResponse.Documents;
        }

        public async Task IndexDocumentAsync(SearchDocument document)
        {
            await _client.IndexAsync(document, idx => idx.Index(_indexName));
        }
    }
}