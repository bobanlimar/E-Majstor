using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UslugeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UslugeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/usluge
        [HttpGet]
        public async Task<IActionResult> GetUsluge()
        {
            var usluge = await _context.Usluge.ToListAsync();
            return Ok(usluge);
        }

        // GET: api/v1/usluge/majstor/{majstorId}
        [HttpGet("majstor/{majstorId}")]
        public async Task<IActionResult> GetUslugeZaMajstora(int majstorId)
        {
            var usluge = await _context.Usluge
                .Where(u => u.MajstorId == majstorId)
                .ToListAsync();

            return Ok(usluge);
        }

        // POST: api/v1/usluge
        [HttpPost]
        public async Task<IActionResult> DodajUslugu([FromBody] Usluga usluga)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Usluge.Add(usluga);
            await _context.SaveChangesAsync();

            return Ok(new { poruka = "Usluga je uspešno dodata!", usluga });
        }
    }
}
