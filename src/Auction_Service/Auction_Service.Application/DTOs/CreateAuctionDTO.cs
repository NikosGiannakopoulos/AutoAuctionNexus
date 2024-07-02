namespace Auction_Service.Application.DTOs
{
    public class CreateAuctionDTO
    {
        public int ReservePrice { get; set; }
        public int? StartingBidPrice { get; set; }
        public int? BuyItNowPrice { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HP { get; set; }
        public int CC { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string Category { get; set; }
        public List<string> ImageUrls { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
    }
}