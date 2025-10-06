using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Data;
using wmsmagazyn.Models;

namespace wmsmagazyn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            return _context.Locations.ToList();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location == null) return NotFound();
            return location;
        }

        // POST: api/Locations
        [HttpPost]
        public ActionResult<Location> CreateLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, Location location)
        {
            if (id != location.Id) return BadRequest();

            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location == null) return NotFound();

            _context.Locations.Remove(location);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
