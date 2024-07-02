using Auction_Service.Application.DTOs;
using Auction_Service.Domain.Entities.Enums;
using Auction_Service.Application.Extensions;
using Auction_Service.Domain.Repositories.Interfaces;
using Auction_Service.Application.Services.Interfaces;

namespace Auction_Service.Application.Services.Implementations
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _repository;

        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AuctionDTO>> GetAllAuctionsAsync()
        {
            var auctions = await _repository.GetAllAsync();
            return auctions.Select(auction => auction.ToAuctionDTO()).ToList();
        }

        public async Task<AuctionDTO> GetAuctionByIdAsync(Guid id)
        {
            var auction = await _repository.GetByIdAsync(id);
            return auction.ToAuctionDTO();
        }

        public async Task CreateAuctionAsync(CreateAuctionDTO createAuctionDTO)
        {
            var auction = createAuctionDTO.ToAuction();
            await _repository.CreateAsync(auction);
        }

        public async Task UpdateAuctionAsync(Guid id, UpdateAuctionDTO updateAuctionDTO)
        {
            var auction = await _repository.GetByIdAsync(id);
            if (auction.Status == Status.NotStarted)
            {
                updateAuctionDTO.ApplyToAuction(auction);
                await _repository.UpdateAsync(id, auction);
            }
        }

        public async Task DeleteAuctionAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}