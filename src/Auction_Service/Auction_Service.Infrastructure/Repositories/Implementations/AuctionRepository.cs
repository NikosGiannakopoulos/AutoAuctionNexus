using Microsoft.EntityFrameworkCore;
using Auction_Service.Domain.Entities;
using Result_Manager.Results.Generics;
using Auction_Service.Application.Errors;
using Auction_Service.Infrastructure.Data;
using Result_Manager.Results.Non_Generics;
using Auction_Service.Domain.Repositories.Interfaces;

namespace Auction_Service.Infrastructure.Repositories.Implementations
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;

        public AuctionRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Auction>>> GetAllAsync()
        {
            try
            {
                var auctions = await _context.Auctions.Include(x => x.Vehicle).ToListAsync();
                return Result<IEnumerable<Auction>>.Success(auctions);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Auction>>.Failure(AuctionErrors.AuctionRetrievalFailed);
            }
        }

        public async Task<Result<Auction>> GetByIdAsync(Guid id)
        {
            try
            {
                var auction = await _context.Auctions.Include(x => x.Vehicle).FirstOrDefaultAsync(x => x.Id == id);
                if (auction == null)
                    return Result<Auction>.Failure(AuctionErrors.AuctionNotFound);

                return Result<Auction>.Success(auction);
            }
            catch (Exception ex)
            {
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
                return Result.Success();
            }
            catch (Exception ex)
            {
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
                    return Result.Failure(AuctionErrors.AuctionNotFound);

                _context.Entry(existingAuction).CurrentValues.SetValues(auction);
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(AuctionErrors.AuctionUpdateFailed);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var auction = await _context.Auctions.FindAsync(id);
                if (auction == null)
                    return Result.Failure(AuctionErrors.AuctionNotFound);

                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(AuctionErrors.AuctionDeletionFailed);
            }
        }
    }
}