using Search_Service.Domain.Entities;

namespace Search_Service.Application.Services.Interfaces
{
    public interface ISearchService
    {
        Task<List<SearchDocument>> SearchDocumentAsync(string query);
        Task IndexDocumentAsync(SearchDocument document);
    }
}