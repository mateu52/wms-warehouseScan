using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Data;
using wmsmagazyn.Models;
using wmsmagazyn.Dto;

namespace wmsmagazyn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StocksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("in")]
        public async Task<IActionResult> AddStockIn(CreateStockMovementDto dto)
        {
            var movement = new StockMovement
            {
                ProductId = dto.ProductId,
                LocationId = dto.LocationId,
                Quantity = dto.Quantity,
                Type = MovementType.IN,
                CreatedAt = DateTime.UtcNow
            };

            _context.StockMovements.Add(movement);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("out")]
        public async Task<IActionResult> AddStockOut(CreateStockMovementDto dto)
        {
            var currentStock = await _context.StockMovements
                .Where(x => x.ProductId == dto.ProductId &&
                            x.LocationId == dto.LocationId)
                .SumAsync(x => x.Type == MovementType.IN
                    ? x.Quantity
                    : -x.Quantity);

            if (currentStock < dto.Quantity)
                return BadRequest("Not enough stock");

            var movement = new StockMovement
            {
                ProductId = dto.ProductId,
                LocationId = dto.LocationId,
                Quantity = dto.Quantity,
                Type = MovementType.OUT,
                CreatedAt = DateTime.UtcNow
            };

            _context.StockMovements.Add(movement);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{productId}/{locationId}")]
        public async Task<IActionResult> GetStock(int productId, int locationId)
        {
            var total = await _context.StockMovements
                .Where(x => x.ProductId == productId &&
                            x.LocationId == locationId)
                .SumAsync(x => x.Type == MovementType.IN
                    ? x.Quantity
                    : -x.Quantity);

            return Ok(total);
        }
    }
}

