using Auction_Service.Domain.Entities.Enums;

namespace Auction_Service.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HP { get; set; }
        public int CC { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public Category Category { get; set; }
        public List<string> ImageUrls { get; set; }
        public Auction Auction { get; set; }
        public Guid AuctionId { get; set; }
    }
}