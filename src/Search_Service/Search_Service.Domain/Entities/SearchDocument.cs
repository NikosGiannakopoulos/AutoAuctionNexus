namespace Search_Service.Domain.Entities
{
    public class SearchDocument
    {
        public Guid Id { get; set; }
        public int ReservePrice { get; set; }
        public int StartingBidPrice { get; set; }
        public int BuyItNowPrice { get; set; }
        public string Seller { get; set; }
        public string Winner { get; set; }
        public int SoldAmount { get; set; }
        public int CurrentHighBid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public string Status { get; set; }
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
    }
}