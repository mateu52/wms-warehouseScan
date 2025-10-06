using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Data;
using wmsmagazyn.Models;

namespace wmsmagazyn.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly AppDbContext _context;
            public ProductsController(AppDbContext context)
            {
                _context = context;
            }
            [HttpGet]
            public IActionResult GetAll()
            {
                var products = _context.Products
                    .Include(p => p.DefaultLocation)
                    .ToList();
                return Ok(products);
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
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
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
