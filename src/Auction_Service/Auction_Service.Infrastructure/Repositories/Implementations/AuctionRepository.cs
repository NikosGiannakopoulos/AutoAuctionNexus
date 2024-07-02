using Microsoft.EntityFrameworkCore;
using Auction_Service.Domain.Entities;
using Auction_Service.Infrastructure.Data;
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

        public async Task<IEnumerable<Auction>> GetAllAsync()
            => await _context.Auctions.Include(x => x.Vehicle).ToListAsync();

        public async Task<Auction?> GetByIdAsync(Guid id)
            => await _context.Auctions.Include(x => x.Vehicle).FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, Auction auction)
        {
            var existingAuction = await _context.Auctions.FindAsync(id);
            if (existingAuction != null)
            {
                _context.Entry(existingAuction).CurrentValues.SetValues(auction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction != null)
            {
                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
            }
        }
    }
}