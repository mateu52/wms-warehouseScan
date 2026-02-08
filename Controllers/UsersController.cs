using Microsoft.AspNetCore.Mvc;
using wmsmagazyn.Data;
using wmsmagazyn.Models;

namespace wmsmagazyn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.Users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
