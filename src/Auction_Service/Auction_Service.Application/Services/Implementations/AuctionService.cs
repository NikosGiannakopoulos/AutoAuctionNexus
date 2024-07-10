using Result_Manager.Results.Generics;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Errors;
using Result_Manager.Results.Non_Generics;
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

        public async Task<Result<List<AuctionDTO>>> GetAllAuctionsAsync()
        {
            var result = await _repository.GetAllAsync();
            if (result.IsFailure)
                return Result<List<AuctionDTO>>.Failure(result.Error);

            var auctionDTOs = result.Data.Select(auction => auction.ToAuctionDTO()).ToList();
            return Result<List<AuctionDTO>>.Success(auctionDTOs);
        }

        public async Task<Result<AuctionDTO>> GetAuctionByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result.IsFailure)
                return Result<AuctionDTO>.Failure(result.Error);

            var auctionDTO = result.Data.ToAuctionDTO();
            return Result<AuctionDTO>.Success(auctionDTO);
        }

        public async Task<Result> CreateAuctionAsync(CreateAuctionDTO createAuctionDTO)
        {
            var auction = createAuctionDTO.ToAuction();
            var result = await _repository.CreateAsync(auction);
            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }

        public async Task<Result> UpdateAuctionAsync(Guid id, UpdateAuctionDTO updateAuctionDTO)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result.IsFailure)
                return Result.Failure(result.Error);

            if (result.Data.Status != Status.NotStarted)
                return Result.Failure(AuctionErrors.AuctionAlreadyStarted);

            updateAuctionDTO.ApplyToAuction(result.Data);
            var updateResult = await _repository.UpdateAsync(id, result.Data);
            if (updateResult.IsFailure)
                return Result.Failure(updateResult.Error);

            return Result.Success();
        }

        public async Task<Result> DeleteAuctionAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }
    }
}