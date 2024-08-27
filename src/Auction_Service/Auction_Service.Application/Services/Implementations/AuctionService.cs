using Microsoft.Extensions.Logging;
using Result_Manager.Results.Generics;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Errors;
using Result_Manager.Results.Non_Generics;
using Auction_Service.Application.Mappings;
using Auction_Service.Domain.Entities.Enums;
using Auction_Service.Domain.Repositories.Interfaces;
using Auction_Service.Application.Services.Interfaces;

namespace Auction_Service.Application.Services.Implementations
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _repository;
        private readonly ILogger<AuctionService> _logger;

        public AuctionService(IAuctionRepository repository, ILogger<AuctionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<List<AuctionDTO>>> GetAllAuctionsAsync()
        {
            _logger.LogInformation("Fetching all auctions.");
            var result = await _repository.GetAllAsync();
            if (result.IsFailure)
            {
                _logger.LogError("Failed to fetch auctions: {Error}", result.Error.Message);
                return Result<List<AuctionDTO>>.Failure(result.Error);
            }

            var auctionDTOs = result.Data.Select(auction => MappingConfig.MapToAuctionDTO(auction)).ToList();
            return Result<List<AuctionDTO>>.Success(auctionDTOs);
        }

        public async Task<Result<AuctionDTO>> GetAuctionByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching auction with ID: {AuctionId}", id);
            var result = await _repository.GetByIdAsync(id);
            if (result.IsFailure)
            {
                _logger.LogError("Failed to fetch auction with ID {AuctionId}: {Error}", id, result.Error.Message);
                return Result<AuctionDTO>.Failure(result.Error);
            }

            var auctionDTO = MappingConfig.MapToAuctionDTO(result.Data);
            return Result<AuctionDTO>.Success(auctionDTO);
        }

        public async Task<Result> CreateAuctionAsync(CreateAuctionDTO createAuctionDTO)
        {
            _logger.LogInformation("Creating new auction.");
            var auction = MappingConfig.MapToAuction(createAuctionDTO);
            var result = await _repository.CreateAsync(auction);
            if (result.IsFailure)
            {
                _logger.LogError("Failed to create auction: {Error}", result.Error.Message);
                return Result.Failure(result.Error);
            }

            _logger.LogInformation("Auction created successfully.");
            return Result.Success();
        }

        public async Task<Result> UpdateAuctionAsync(Guid id, UpdateAuctionDTO updateAuctionDTO)
        {
            _logger.LogInformation("Updating auction with ID: {AuctionId}", id);
            var result = await _repository.GetByIdAsync(id);
            if (result.IsFailure)
            {
                _logger.LogError("Failed to fetch auction with ID {AuctionId}: {Error}", id, result.Error.Message);
                return Result.Failure(result.Error);
            }

            if (result.Data.Status != Status.NotStarted)
            {
                _logger.LogWarning("Auction with ID {AuctionId} already started. Update not allowed.", id);
                return Result.Failure(AuctionErrors.AuctionAlreadyStarted);
            }

            MappingConfig.ApplyToAuction(updateAuctionDTO, result.Data);
            var updateResult = await _repository.UpdateAsync(id, result.Data);
            if (updateResult.IsFailure)
            {
                _logger.LogError("Failed to update auction with ID {AuctionId}: {Error}", id, updateResult.Error.Message);
                return Result.Failure(updateResult.Error);
            }

            _logger.LogInformation("Auction with ID {AuctionId} updated successfully.", id);
            return Result.Success();
        }

        public async Task<Result> DeleteAuctionAsync(Guid id)
        {
            _logger.LogInformation("Deleting auction with ID: {AuctionId}", id);
            var result = await _repository.DeleteAsync(id);
            if (result.IsFailure)
            {
                _logger.LogError("Failed to delete auction with ID {AuctionId}: {Error}", id, result.Error.Message);
                return Result.Failure(result.Error);
            }

            _logger.LogInformation("Auction with ID {AuctionId} deleted successfully.", id);
            return Result.Success();
        }
    }
}