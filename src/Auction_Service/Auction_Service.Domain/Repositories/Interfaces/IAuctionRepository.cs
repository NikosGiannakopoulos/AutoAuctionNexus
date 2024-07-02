using Auction_Service.Domain.Entities;

namespace Auction_Service.Domain.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetAllAsync();
        Task<Auction?> GetByIdAsync(Guid id);
        Task CreateAsync(Auction auction);
        Task UpdateAsync(Guid id, Auction auction);
        Task DeleteAsync(Guid id);
    }
}