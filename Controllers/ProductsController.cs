using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Data;
using wmsmagazyn.Dto;
using wmsmagazyn.Models;

namespace wmsmagazyn.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
    public class ProductsController : ControllerBase
        {
            private readonly AppDbContext _context;
            public ProductsController(AppDbContext context)
            {
                _context = context;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProductWithUserDto>>> GetProducts()
            {
                var products = await _context.Products
                    .Include(p => p.CreatedByUser)
                    .ToListAsync();

                var result = products.Select(p => new ProductWithUserDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Barcode = p.Barcode,
                    Unit = p.Unit,
                    Price = p.Price,
                    CreatedByUser = p.CreatedByUser == null ? null : new UserDto
                    {
                        Id = p.CreatedByUser.Id,
                        Name = p.CreatedByUser.Name,
                        Surname = p.CreatedByUser.Surname,
                        Role = p.CreatedByUser.Role
                    }
                }).ToList();

                return Ok(result);
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            [HttpPost]
            [Authorize]
            public async Task<ActionResult<Product>> Create(Product product)
            {
                // Pobranie UserId z tokena
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
                {
                    return Unauthorized("Brak identyfikatora użytkownika w tokenie.");
                }
                var userId = int.Parse(userIdClaim.Value);
                product.CreatedByUserId = userId;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            [HttpPut("{id}")]
            public IActionResult Update(int id, Product product)
            {
                var existingProduct = _context.Products.Find(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }
                existingProduct.Name = product.Name;
                existingProduct.Barcode = product.Barcode;
                existingProduct.Unit = product.Unit;
                existingProduct.Price = product.Price;
                existingProduct.DefaultLocationId = product.DefaultLocationId;
                _context.SaveChanges();
                return NoContent();
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return NoContent();
            }
        }
    
}
