using Auction_Service.Domain.Entities.Enums;

namespace Auction_Service.Domain.Entities
{
    public class Auction
    {
        public Guid Id { get; set; }
        public int ReservePrice { get; set; } = 0;
        public int? StartingBidPrice { get; set; } = 1;
        public int? BuyItNowPrice { get; set; }
        public string Seller { get; set; }
        public string Winner { get; set; }
        public int? SoldAmount { get; set; }
        public int? CurrentHighBid { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public Status Status => CalculateStatus();
        public Vehicle Vehicle { get; set; }

        private Status CalculateStatus()
        {
            return DateTime.UtcNow switch
            {
                var time when time < AuctionStart => Status.NotStarted,
                var time when time >= AuctionStart && time < AuctionEnd => Status.Live,
                _ => (CurrentHighBid ?? 0) >= ReservePrice ? Status.Finished : Status.ReserveNotMet
            };
        }
    }
}