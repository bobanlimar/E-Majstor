using Microsoft.EntityFrameworkCore;
using eMajstor.API.Models;

namespace eMajstor.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Majstor> Majstori { get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<Zahtev> Zahtevi { get; set; }
        public DbSet<Ocena> Ocene { get; set; }
        public DbSet<Poruka> Poruke { get; set; }
    }
}