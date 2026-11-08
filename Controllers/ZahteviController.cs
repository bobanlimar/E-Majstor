using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ZahteviController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZahteviController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/zahtevi
        [HttpGet]
        public async Task<IActionResult> GetZahtevi()
        {
            var zahtevi = await _context.Zahtevi.ToListAsync();
            return Ok(zahtevi);
        }

        // GET: api/v1/zahtevi/klijent/{klijentId}
        [HttpGet("klijent/{klijentId}")]
        public async Task<IActionResult> GetZahteviZaKlijenta(int klijentId)
        {
            var zahtevi = await _context.Zahtevi
                .Where(z => z.KlijentId == klijentId)
                .ToListAsync();

            return Ok(zahtevi);
        }

        // POST: api/v1/zahtevi
        [HttpPost]
        public async Task<IActionResult> KreirajZahtev([FromBody] Zahtev zahtev)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Zahtevi.Add(zahtev);
            await _context.SaveChangesAsync();

            return Ok(new { poruka = "Zahtev je uspešno kreiran!", zahtev });
        }
    }
}
