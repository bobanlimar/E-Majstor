using Microsoft.EntityFrameworkCore;
using eMajstor.API.Models;

namespace eMajstor.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Majstor> Majstori { get; set; }
    }
}