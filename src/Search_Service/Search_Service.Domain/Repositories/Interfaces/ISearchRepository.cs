using Search_Service.Domain.Entities;

namespace Search_Service.Domain.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        Task<IEnumerable<SearchDocument>> SearchAsync(string query);
        Task IndexDocumentAsync(SearchDocument document);
    }
}