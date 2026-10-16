using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UpitiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UpitiController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/v1/upiti (Klijent šalje novi upit/zahtev)
        [HttpPost]
        public async Task<IActionResult> PosaljiUpit([FromBody] Zahtev zahtev)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            zahtev.DatumZahteva = DateTime.UtcNow;
            _context.Zahtevi.Add(zahtev);
            await _context.SaveChangesAsync();

            return Ok(new { poruka = "Zahtev je uspešno poslat!", zahtev });
        }

        // GET: api/v1/upiti/majstor/{majstorId} (Pregled zahteva za određenog majstora)
        [HttpGet("majstor/{majstorId}")]
        public async Task<IActionResult> GetUpitiZaMajstora(int majstorId)
        {
            var upiti = await _context.Zahtevi
                .Where(z => z.MajstorId == majstorId)
                .ToListAsync();

            return Ok(upiti);
        }
    }
}
