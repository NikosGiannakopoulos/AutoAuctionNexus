using Auction_Service.Application.DTOs;
using Result_Management_Service.Results.Generics;
using Result_Management_Service.Results.Non_Generics;

namespace Auction_Service.Application.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<Result<List<AuctionDTO>>> GetAllAuctionsAsync();
        Task<Result<AuctionDTO>> GetAuctionByIdAsync(Guid id);
        Task<Result> CreateAuctionAsync(CreateAuctionDTO createAuctionDTO);
        Task<Result> UpdateAuctionAsync(Guid id, UpdateAuctionDTO updateAuctionDTO);
        Task<Result> DeleteAuctionAsync(Guid id);
    }
}