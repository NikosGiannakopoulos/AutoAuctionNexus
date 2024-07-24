using Microsoft.AspNetCore.Mvc;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Mappings;
using Result_Manager.Results.Generics.Extensions;
using Result_Manager.Results.Non_Generics.Extensions;
using Auction_Service.Application.Services.Interfaces;

namespace Auction_Service.Presentation.Controllers
{
    [Route("api/auctions")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _service;

        public AuctionController(IAuctionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDTO>>> GetAllAuctions()
        {
            var result = await _service.GetAllAuctionsAsync();

            return result.Match(
                onSuccess: auctions => Ok(auctions),
                onFailure: error =>
                {
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
            var result = await _service.GetAuctionByIdAsync(id);

            return result.Match(
                onSuccess: auction => Ok(auction),
                onFailure: error =>
                {
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var auction = MappingConfig.MapToAuction(createAuctionDTO);

            var result = await _service.CreateAuctionAsync(createAuctionDTO);

            return result.Match(
                onSuccess: () =>
                {
                    var auctionDTO = MappingConfig.MapToAuctionDTO(auction);
                    return CreatedAtAction(nameof(GetAuctionById), new { auctionDTO.Id }, auctionDTO);

                },
                onFailure: error =>
                {
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
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null) return NotFound();

            var result = await _service.UpdateAuctionAsync(id, updateAuctionDTO);

            return result.Match<ActionResult>(
                onSuccess: () => NoContent(),
                onFailure: error =>
                {
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
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null) return NotFound();

            var result = await _service.DeleteAuctionAsync(id);

            return result.Match<ActionResult>(
                onSuccess: () => NoContent(),
                onFailure: error =>
                {
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