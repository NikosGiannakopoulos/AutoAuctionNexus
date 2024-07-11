using Auction_Service.Domain.Entities;
using Auction_Service.Application.DTOs;
using Auction_Service.Domain.Entities.Enums;

namespace Auction_Service.Application.Mappings
{
    public static class MappingConfig
    {
        public static AuctionDTO MapToAuctionDTO(Auction auction)
        {
            if (auction == null) return null;

            return new AuctionDTO
            {
                Id = auction.Id,
                ReservePrice = auction.ReservePrice,
                StartingBidPrice = auction.StartingBidPrice ?? 0,
                BuyItNowPrice = auction.BuyItNowPrice ?? 0,
                Seller = auction.Seller,
                Winner = auction.Winner,
                SoldAmount = auction.SoldAmount ?? 0,
                CurrentHighBid = auction.CurrentHighBid ?? 0,
                CreatedAt = auction.CreatedAt,
                UpdatedAt = auction.UpdatedAt,
                AuctionStart = auction.AuctionStart,
                AuctionEnd = auction.AuctionEnd,
                Status = auction.Status.ToString(),
                Manufacturer = auction.Vehicle?.Manufacturer,
                Model = auction.Vehicle?.Model,
                Year = auction.Vehicle?.Year ?? 0,
                HP = auction.Vehicle?.HP ?? 0,
                CC = auction.Vehicle?.CC ?? 0,
                Color = auction.Vehicle?.Color,
                Mileage = auction.Vehicle?.Mileage ?? 0,
                VIN = auction.Vehicle?.VIN,
                Description = auction.Vehicle?.Description,
                Condition = auction.Vehicle?.Condition.ToString(),
                Category = auction.Vehicle?.Category.ToString(),
                ImageUrls = auction.Vehicle?.ImageUrls ?? []
            };
        }

        public static Auction MapToAuction(CreateAuctionDTO createAuctionDTO)
        {
            if (createAuctionDTO == null) return null;

            return new Auction
            {
                Id = Guid.NewGuid(),
                ReservePrice = createAuctionDTO.ReservePrice,
                StartingBidPrice = createAuctionDTO.StartingBidPrice,
                BuyItNowPrice = createAuctionDTO.BuyItNowPrice,
                AuctionStart = createAuctionDTO.AuctionStart,
                AuctionEnd = createAuctionDTO.AuctionEnd,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = createAuctionDTO.Manufacturer,
                    Model = createAuctionDTO.Model,
                    Year = createAuctionDTO.Year,
                    HP = createAuctionDTO.HP,
                    CC = createAuctionDTO.CC,
                    Color = createAuctionDTO.Color,
                    Mileage = createAuctionDTO.Mileage,
                    VIN = createAuctionDTO.VIN,
                    Description = createAuctionDTO.Description,
                    Condition = Enum.TryParse(createAuctionDTO.Condition, true, out Condition condition) ? condition : default,
                    Category = Enum.TryParse(createAuctionDTO.Category, true, out Category category) ? category : default,
                    ImageUrls = createAuctionDTO.ImageUrls ?? []
                }
            };
        }

        public static void ApplyToAuction(UpdateAuctionDTO updateAuctionDTO, Auction auction)
        {
            auction.ReservePrice = updateAuctionDTO.ReservePrice ?? auction.ReservePrice;
            auction.StartingBidPrice = updateAuctionDTO.StartingBidPrice ?? auction.StartingBidPrice;
            auction.BuyItNowPrice = updateAuctionDTO.BuyItNowPrice ?? auction.BuyItNowPrice;
            auction.Vehicle.Manufacturer = updateAuctionDTO.Manufacturer ?? auction.Vehicle.Manufacturer;
            auction.Vehicle.Model = updateAuctionDTO.Model ?? auction.Vehicle.Model;
            auction.Vehicle.Year = updateAuctionDTO.Year ?? auction.Vehicle.Year;
            auction.Vehicle.HP = updateAuctionDTO.HP ?? auction.Vehicle.HP;
            auction.Vehicle.CC = updateAuctionDTO.CC ?? auction.Vehicle.CC;
            auction.Vehicle.Color = updateAuctionDTO.Color ?? auction.Vehicle.Color;
            auction.Vehicle.Mileage = updateAuctionDTO.Mileage ?? auction.Vehicle.Mileage;
            auction.Vehicle.VIN = updateAuctionDTO.VIN ?? auction.Vehicle.VIN;
            auction.Vehicle.Description = updateAuctionDTO.Description ?? auction.Vehicle.Description;
            auction.Vehicle.Condition = Enum.TryParse(updateAuctionDTO.Condition, out Condition condition) ? condition : auction.Vehicle.Condition;
            auction.Vehicle.Category = Enum.TryParse(updateAuctionDTO.Category, out Category category) ? category : auction.Vehicle.Category;
            auction.Vehicle.ImageUrls = updateAuctionDTO.ImageUrls ?? auction.Vehicle.ImageUrls;
            auction.AuctionStart = updateAuctionDTO.AuctionStart ?? auction.AuctionStart;
            auction.AuctionEnd = updateAuctionDTO.AuctionEnd ?? auction.AuctionEnd;
        }
    }
}