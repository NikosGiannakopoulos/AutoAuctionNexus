using Auction_Service.Domain.Entities;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Mappings;
using Auction_Service.Domain.Entities.Enums;

namespace Auction_Service.Application.Extensions
{
    public static class CompositeMappingConfig
    {
        public static AuctionDTO ToAuctionDTO(this Auction auction)
        {
            var auctionDTO = auction.MapToAuctionDTO();
            auction.Vehicle.MapToAuctionDTO();
            return auctionDTO;
        }

        public static Auction ToAuction(this CreateAuctionDTO createAuctionDTO)
        {
            var auction = createAuctionDTO.MapToAuction();
            auction.Vehicle = createAuctionDTO.MapToVehicle();
            return auction;
        }

        public static void ApplyToAuction(this UpdateAuctionDTO updateAuctionDTO, Auction auction)
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