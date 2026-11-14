using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eMajstor.API.Data;
using eMajstor.API.Models;

namespace eMajstor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KategorijeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KategorijeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/kategorije
        [HttpGet]
        public async Task<IActionResult> GetKategorije()
        {
            var kategorije = await _context.Kategorije
                .AsNoTracking()
                .ToListAsync();

            return Ok(kategorije);
        }
    }
}
