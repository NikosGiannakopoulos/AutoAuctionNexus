using Auction_Service.Domain.Entities;
using Result_Manager.Results.Generics;
using Result_Manager.Results.Non_Generics;

namespace Auction_Service.Domain.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Result<IEnumerable<Auction>>> GetAllAsync();
        Task<Result<Auction>> GetByIdAsync(Guid id);
        Task<Result> CreateAsync(Auction auction);
        Task<Result> UpdateAsync(Guid id, Auction auction);
        Task<Result> DeleteAsync(Guid id);
    }
}