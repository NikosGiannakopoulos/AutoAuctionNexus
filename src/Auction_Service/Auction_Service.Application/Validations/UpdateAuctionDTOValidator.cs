using FluentValidation;
using Auction_Service.Application.DTOs;

namespace Auction_Service.Application.Validations
{
    public class UpdateAuctionDTOValidator : AbstractValidator<UpdateAuctionDTO>
    {
        public UpdateAuctionDTOValidator()
        {
            RuleFor(c => c.ReservePrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ReservePrice must be greater than or equal to 0");

            RuleFor(c => c.StartingBidPrice)
                .GreaterThanOrEqualTo(1)
                .When(c => c.StartingBidPrice.HasValue)
                .WithMessage("StartingBidPrice must be greater than or equal to 1");

            RuleFor(c => c.BuyItNowPrice)
                .GreaterThanOrEqualTo(1)
                .When(c => c.BuyItNowPrice.HasValue)
                .WithMessage("BuyItNowPrice must be greater than or equal to 1");

            RuleFor(c => c.Year)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Year cannot be in the future");

            RuleFor(x => x.HP)
                .GreaterThanOrEqualTo(1)
                .WithMessage("HP must be greater than or equal to 1");

            RuleFor(x => x.CC)
                .GreaterThanOrEqualTo(1)
                .WithMessage("CC must be greater than or equal to 1");

            RuleFor(x => x.Mileage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Mileage must be greater than or equal to 0");

            RuleFor(x => x.VIN)
                .Length(17)
                .WithMessage("VIN must be exactly 17 characters long");

            RuleFor(c => c.ImageUrls)
                .NotEmpty()
                .WithMessage("ImageUrls must contain at least one item");

            RuleFor(x => x.AuctionStart)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("AuctionStart cannot be in the past");

            RuleFor(x => x.AuctionEnd)
                .GreaterThan(x => x.AuctionStart)
                .WithMessage("AuctionEnd must be after AuctionStart");
        }
    }
}