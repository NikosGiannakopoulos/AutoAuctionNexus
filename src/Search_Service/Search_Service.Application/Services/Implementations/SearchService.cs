using Search_Service.Domain.Entities;
using Search_Service.Domain.Repositories.Interfaces;
using Search_Service.Application.Services.Interfaces;

namespace Search_Service.Application.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<List<SearchDocument>> SearchDocumentAsync(string query)
        {
            var documents = await _searchRepository.SearchAsync(query);
            return documents.ToList();
        }

        public async Task IndexDocumentAsync(SearchDocument document)
        {
            await _searchRepository.IndexDocumentAsync(document);
        }
    }
}