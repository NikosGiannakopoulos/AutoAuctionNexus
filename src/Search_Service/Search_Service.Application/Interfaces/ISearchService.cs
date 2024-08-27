using Search_Service.Domain.Entities;

namespace Search_Service.Application.Interfaces
{
    public interface ISearchService
    {
        Task IndexDocumentAsync(SearchDocument document);
        Task<IEnumerable<SearchDocument>> SearchAsync(string query);
    }
}