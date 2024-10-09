using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Auction_Service.Domain.Entities;
using Auction_Service.Application.Errors;
using Auction_Service.Infrastructure.Data;
using Result_Management_Service.Results.Generics;
using Auction_Service.Domain.Repositories.Interfaces;
using Result_Management_Service.Results.Non_Generics;

namespace Auction_Service.Infrastructure.Repositories.Implementations
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;
        private readonly ILogger<AuctionRepository> _logger;

        public AuctionRepository(AuctionDbContext context, ILogger<AuctionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<Auction>>> GetAllAsync()
        {
            try
            {
                var auctions = await _context.Auctions
                                             .Include(x => x.Vehicle)
                                             .AsNoTracking()
                                             .ToListAsync();

                _logger.LogInformation("All auctions retrieved successfully.");
                return Result<IEnumerable<Auction>>.Success(auctions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all auctions.");
                return Result<IEnumerable<Auction>>.Failure(AuctionErrors.AuctionRetrievalFailed);
            }
        }

        public async Task<Result<Auction>> GetByIdAsync(Guid id)
        {
            try
            {
                var auction = await _context.Auctions
                                            .Include(x => x.Vehicle)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == id);
                if (auction == null)
                {
                    _logger.LogWarning("Auction with Id {AuctionId} not found for retrieval.", id);
                    return Result<Auction>.Failure(AuctionErrors.AuctionNotFound);
                }

                _logger.LogInformation("Auction with Id {AuctionId} retrieved successfully.", id);
                return Result<Auction>.Success(auction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving auction with Id {AuctionId}.", id);
                return Result<Auction>.Failure(AuctionErrors.AuctionRetrievalFailed);
            }
        }

        public async Task<Result> CreateAsync(Auction auction)
        {
            ArgumentNullException.ThrowIfNull(auction);

            try
            {
                await _context.Auctions.AddAsync(auction);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with Id {AuctionId} created successfully.", auction.Id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating auction.");
                return Result.Failure(AuctionErrors.AuctionCreationFailed);
            }
        }

        public async Task<Result> UpdateAsync(Guid id, Auction auction)
        {
            ArgumentNullException.ThrowIfNull(auction);

            try
            {
                var existingAuction = await _context.Auctions.FindAsync(id);
                if (existingAuction == null)
                {
                    _logger.LogWarning("Auction with Id {AuctionId} not found for update.", id);
                    return Result.Failure(AuctionErrors.AuctionNotFound);
                }

                _context.Entry(existingAuction).CurrentValues.SetValues(auction);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with Id {AuctionId} updated successfully.", id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating auction with Id {AuctionId}.", id);
                return Result.Failure(AuctionErrors.AuctionUpdateFailed);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var auction = await _context.Auctions.FindAsync(id);
                if (auction == null)
                {
                    _logger.LogWarning("Auction with Id {AuctionId} not found for deletion.", id);
                    return Result.Failure(AuctionErrors.AuctionNotFound);
                }

                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Auction with Id {AuctionId} deleted successfully.", id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting auction with Id {AuctionId}.", id);
                return Result.Failure(AuctionErrors.AuctionDeletionFailed);
            }
        }
    }
}