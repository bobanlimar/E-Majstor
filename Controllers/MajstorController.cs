using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MajstorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MajstorController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/v1/Majstor (Lista svih majstora uz opciono filtriranje po kategoriji)
        [HttpGet]
        public async Task<IActionResult> GetMajstori([FromQuery] string? kategorija)
        {
            var query = _context.Majstori
                .Include(m => m.User)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(kategorija))
            {
                query = query.Where(m => m.Kategorija.ToLower() == kategorija.ToLower());
            }

            var majstori = await query.ToListAsync();
            return Ok(majstori);
        }

        // 2. GET: api/v1/Majstor/{id} (Pregled profila majstora po ID-ju)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajstorById(int id)
        {
            var majstor = await _context.Majstori
                .Include(m => m.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (majstor == null)
            {
                return NotFound(new { poruka = "Majstor nije pronađen." });
            }

            return Ok(majstor);
        }

        // 3. PUT: api/v1/Majstor/{id} (Ažuriranje profila majstora)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfil(int id, [FromBody] Majstor majstorUpdate)
        {
            // Ostaje standardno bez AsNoTracking jer se podaci ažuriraju
            if (id != majstorUpdate.Id)
            {
                return BadRequest(new { poruka = "ID se ne poklapa." });
            }

            var postojeciMajstor = await _context.Majstori.FindAsync(id);
            if (postojeciMajstor == null)
            {
                return NotFound(new { poruka = "Majstor nije pronađen." });
            }

            postojeciMajstor.Kategorija = majstorUpdate.Kategorija;
            postojeciMajstor.Opis = majstorUpdate.Opis;
            // Dodaj ostala polja po potrebi

            await _context.SaveChangesAsync();

            return Ok(new { poruka = "Profil je uspešno ažuriran!", postojeciMajstor });
        }
    }
}
