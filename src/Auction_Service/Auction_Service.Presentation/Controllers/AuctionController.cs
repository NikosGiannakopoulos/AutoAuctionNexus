using Microsoft.AspNetCore.Mvc;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Mappings;
using Auction_Service.Application.Services.Interfaces;
using Result_Management_Service.Results.Generics.Extensions;
using Result_Management_Service.Results.Non_Generics.Extensions;

namespace Auction_Service.Presentation.Controllers
{
    [Route("api/auctions")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _service;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(IAuctionService service, ILogger<AuctionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDTO>>> GetAllAuctions()
        {
            _logger.LogInformation("Fetching all auctions.");
            var result = await _service.GetAllAuctionsAsync();

            return result.Match(
                onSuccess: auctions =>
                {
                    _logger.LogInformation("Successfully retrieved {Count} auctions.", auctions.Count);
                    return Ok(auctions);
                },
                onFailure: error =>
                {
                    _logger.LogError("Error fetching auctions: {ErrorCode} - {ErrorMessage}", error.Code, error.Message);
                    return error.Code switch
                    {
                        "Auction_Service.AuctionRetrievalFailed" => StatusCode(500, error.Message),
                        _ => StatusCode(500, error.Message)
                    };
                }
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDTO>> GetAuctionById(Guid id)
        {
            _logger.LogInformation("Fetching auction with ID {AuctionId}.", id);
            var result = await _service.GetAuctionByIdAsync(id);

            return result.Match(
                onSuccess: auction =>
                {
                    _logger.LogInformation("Successfully retrieved auction with ID {AuctionId}.", id);
                    return Ok(auction);
                },
                onFailure: error =>
                {
                    _logger.LogWarning("Error fetching auction with ID {AuctionId}: {ErrorCode} - {ErrorMessage}", id, error.Code, error.Message);
                    return error.Code switch
                    {
                        "Auction_Service.AuctionNotFound" => NotFound(error.Message),
                        "Auction_Service.AuctionRetrievalFailed" => StatusCode(500, error.Message),
                        _ => StatusCode(500, error.Message)
                    };
                }
            );
        }

        [HttpPost]
        public async Task<ActionResult<AuctionDTO>> CreateAuction(CreateAuctionDTO createAuctionDTO)
        {
            _logger.LogInformation("Creating a new auction.");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating auction.");
                return BadRequest(ModelState);
            }

            var auction = MappingConfig.MapToAuction(createAuctionDTO);

            var result = await _service.CreateAuctionAsync(createAuctionDTO);

            return result.Match(
                onSuccess: () =>
                {
                    var auctionDTO = MappingConfig.MapToAuctionDTO(auction);
                    _logger.LogInformation("Successfully created auction with ID {AuctionId}.", auctionDTO.Id);
                    return CreatedAtAction(nameof(GetAuctionById), new { auctionDTO.Id }, auctionDTO);
                },
                onFailure: error =>
                {
                    _logger.LogError("Error creating auction: {ErrorCode} - {ErrorMessage}", error.Code, error.Message);
                    return error.Code switch
                    {
                        "Auction_Service.AuctionCreationFailed" => StatusCode(500, error.Message),
                        _ => StatusCode(500, error.Message)
                    };
                }
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDTO updateAuctionDTO)
        {
            _logger.LogInformation("Updating auction with ID {AuctionId}.", id);
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null)
            {
                _logger.LogWarning("Auction with ID {AuctionId} not found for update.", id);
                return NotFound();
            }

            var result = await _service.UpdateAuctionAsync(id, updateAuctionDTO);

            return result.Match<ActionResult>(
                onSuccess: () =>
                {
                    _logger.LogInformation("Successfully updated auction with ID {AuctionId}.", id);
                    return NoContent();
                },
                onFailure: error =>
                {
                    _logger.LogError("Error updating auction with ID {AuctionId}: {ErrorCode} - {ErrorMessage}", id, error.Code, error.Message);
                    return error.Code switch
                    {
                        "Auction_Service.AuctionNotFound" => NotFound(error.Message),
                        "Auction_Service.AuctionUpdateFailed" => StatusCode(500, error.Message),
                        _ => StatusCode(500, error.Message)
                    };
                }
            );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuction(Guid id)
        {
            _logger.LogInformation("Deleting auction with ID {AuctionId}.", id);
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null)
            {
                _logger.LogWarning("Auction with ID {AuctionId} not found for deletion.", id);
                return NotFound();
            }

            var result = await _service.DeleteAuctionAsync(id);

            return result.Match<ActionResult>(
                onSuccess: () =>
                {
                    _logger.LogInformation("Successfully deleted auction with ID {AuctionId}.", id);
                    return NoContent();
                },
                onFailure: error =>
                {
                    _logger.LogError("Error deleting auction with ID {AuctionId}: {ErrorCode} - {ErrorMessage}", id, error.Code, error.Message);
                    return error.Code switch
                    {
                        "Auction_Service.AuctionNotFound" => NotFound(error.Message),
                        "Auction_Service.AuctionDeletionFailed" => StatusCode(500, error.Message),
                        _ => StatusCode(500, error.Message)
                    };
                }
            );
        }
    }
}