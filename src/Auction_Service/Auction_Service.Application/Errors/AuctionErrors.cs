using Result_Management_Service.Errors;

namespace Auction_Service.Application.Errors
{
    public static class AuctionErrors
    {
        public static readonly Error AuctionNotFound = new("Auction_Service.AuctionNotFound", "Auction Not Found");
        public static readonly Error AuctionAlreadyStarted = new("Auction_Service.AuctionAlreadyStarted", "Auction Already Started");

        public static readonly Error AuctionRetrievalFailed = new("Auction_Service.AuctionRetrievalFailed", "An error occurred while retrieving auctions.");
        public static readonly Error AuctionCreationFailed = new("Auction_Service.AuctionCreationFailed", "An error occurred while creating the auction.");
        public static readonly Error AuctionUpdateFailed = new("Auction_Service.AuctionUpdateFailed", "An error occurred while updating the auction.");
        public static readonly Error AuctionDeletionFailed = new("Auction_Service.AuctionDeletionFailed", "An error occurred while deleting the auction.");
    }
}