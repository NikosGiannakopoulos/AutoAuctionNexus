using FluentValidation;
using Auction_Service.Application.DTOs;

namespace Auction_Service.Application.Validations
{
    public class CreateAuctionDTOValidator : AbstractValidator<CreateAuctionDTO>
    {
        public CreateAuctionDTOValidator()
        {
            RuleFor(c => c.ReservePrice)
                .NotNull()
                .WithMessage("ReservePrice is required")
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

            RuleFor(c => c.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required");

            RuleFor(c => c.Model)
                .NotEmpty()
                .WithMessage("Model is required");

            RuleFor(c => c.Year)
                .NotNull()
                .WithMessage("Year is required")
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Year cannot be in the future");

            RuleFor(x => x.HP)
                .NotNull()
                .WithMessage("HP is required")
                .GreaterThanOrEqualTo(1)
                .WithMessage("HP must be greater than or equal to 1");

            RuleFor(x => x.CC)
                .NotNull()
                .WithMessage("CC is required")
                .GreaterThanOrEqualTo(1)
                .WithMessage("CC must be greater than or equal to 1");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Color is required");

            RuleFor(x => x.Mileage)
                .NotNull()
                .WithMessage("Mileage is required")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Mileage must be greater than or equal to 0");

            RuleFor(x => x.VIN)
                .NotEmpty()
                .WithMessage("VIN is required")
                .Length(17)
                .WithMessage("VIN must be exactly 17 characters long");

            RuleFor(x => x.Condition)
                .NotEmpty()
                .WithMessage("Condition is required");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category is required");

            RuleFor(c => c.ImageUrls)
                .NotEmpty()
                .WithMessage("At least one ImageUrl is required");

            RuleFor(x => x.AuctionStart)
                .NotNull()
                .WithMessage("AuctionStart is required")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("AuctionStart cannot be in the past");

            RuleFor(x => x.AuctionEnd)
                .NotNull()
                .WithMessage("AuctionEnd is required")
                .GreaterThan(x => x.AuctionStart)
                .WithMessage("AuctionEnd must be after AuctionStart");
        }
    }
}