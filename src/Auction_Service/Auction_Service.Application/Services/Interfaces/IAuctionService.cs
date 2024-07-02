using Auction_Service.Application.DTOs;

namespace Auction_Service.Application.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<List<AuctionDTO>> GetAllAuctionsAsync();
        Task<AuctionDTO> GetAuctionByIdAsync(Guid id);
        Task CreateAuctionAsync(CreateAuctionDTO createAuctionDTO);
        Task UpdateAuctionAsync(Guid id, UpdateAuctionDTO updateAuctionDTO);
        Task DeleteAuctionAsync(Guid id);
    }
}