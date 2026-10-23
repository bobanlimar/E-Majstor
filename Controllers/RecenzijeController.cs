using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecenzijeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecenzijeController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/v1/Recenzije
        [HttpPost]
        public async Task<IActionResult> DodajRecenziju([FromBody] Ocena recenzija)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Ocene.Add(recenzija);
            await _context.SaveChangesAsync();

            return Ok(new { poruka = "Recenzija je uspešno dodata!", recenzija });
        }

        // GET: api/v1/Recenzije/majstor/{majstorId}
        [HttpGet("majstor/{majstorId}")]
        public async Task<IActionResult> GetRecenzijeZaMajstora(int majstorId)
        {
            var recenzije = await _context.Ocene
                .Where(r => r.MajstorId == majstorId)
                .ToListAsync();

            return Ok(recenzije);
        }
    }
}