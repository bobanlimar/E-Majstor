using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajstorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MajstorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/majstor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Majstor>>> GetMajstori()
        {
            return await _context.Majstori.ToListAsync();
        }

        // GET: api/majstor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Majstor>> GetMajstor(int id)
        {
            var majstor = await _context.Majstori.FindAsync(id);

            if (majstor == null)
            {
                return NotFound("Majstor nije pronađen.");
            }

            return majstor;
        }

        // POST: api/majstor
        [HttpPost]
        public async Task<ActionResult<Majstor>> PostMajstor(Majstor majstor)
        {
            _context.Majstori.Add(majstor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMajstor), new { id = majstor.Id }, majstor);
        }
    }
}