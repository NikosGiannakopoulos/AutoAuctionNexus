using Microsoft.AspNetCore.Mvc;
using Auction_Service.Application.DTOs;
using Auction_Service.Application.Extensions;
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
            var auctions = await _service.GetAllAuctionsAsync();
            return Ok(auctions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDTO>> GetAuctionById(Guid id)
        {
            var auction = await _service.GetAuctionByIdAsync(id);

            if (auction == null) return NotFound();

            return Ok(auction);
        }

        [HttpPost]
        public async Task<ActionResult<AuctionDTO>> CreateAuction(CreateAuctionDTO createAuctionDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var auction = createAuctionDTO.ToAuction();

            await _service.CreateAuctionAsync(createAuctionDTO);

            var auctionDTO = auction.ToAuctionDTO();

            return CreatedAtAction(nameof(GetAuctionById), new { auctionDTO.Id }, auctionDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDTO updateAuctionDTO)
        {
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null) return NotFound();

            await _service.UpdateAuctionAsync(id, updateAuctionDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuction(Guid id)
        {
            var existingAuction = await _service.GetAuctionByIdAsync(id);

            if (existingAuction == null) return NotFound();

            await _service.DeleteAuctionAsync(id);

            return NoContent();
        }
    }
}