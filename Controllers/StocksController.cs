using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Data;
using wmsmagazyn.Dto;
using wmsmagazyn.Models;

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

        [HttpPost]
        public async Task<IActionResult> AddStock(CreateStockDto dto)
        {
            var stock = new Stock
            {
                ProductId = dto.ProductId,
                LocationId = dto.LocationId,
                Quantity = dto.Quantity
            };

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return Ok(stock);
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _context.Stocks
                .Include(s => s.Product)
                .Include(s => s.Location)
                .ToListAsync();

            return Ok(stocks);
        }
    }

}
