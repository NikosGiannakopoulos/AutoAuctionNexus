using Microsoft.EntityFrameworkCore;
using Auction_Service.Domain.Entities;

namespace Auction_Service.Infrastructure.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}