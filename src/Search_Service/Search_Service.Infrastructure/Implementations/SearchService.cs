using Elastic.Clients.Elasticsearch;
using Search_Service.Domain.Entities;
using Search_Service.Application.Interfaces;

namespace Search_Service.Infrastructure.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ElasticsearchClient _client;
        private readonly string _indexName;

        public SearchService()
        {

        }

        public Task IndexDocumentAsync(SearchDocument document)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SearchDocument>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}