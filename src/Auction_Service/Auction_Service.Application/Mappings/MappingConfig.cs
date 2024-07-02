using Riok.Mapperly.Abstractions;
using Auction_Service.Domain.Entities;
using Auction_Service.Application.DTOs;

namespace Auction_Service.Application.Mappings
{
    [Mapper]
    public static partial class MappingConfig
    {
        public static partial AuctionDTO MapToAuctionDTO(this Auction auction);
        public static partial AuctionDTO MapToAuctionDTO(this Vehicle vehicle);
        public static partial Auction MapToAuction(this CreateAuctionDTO createAuctionDTO);
        public static partial Vehicle MapToVehicle(this CreateAuctionDTO createAuctionDTO);
    }
}