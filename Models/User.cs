namespace eMajstor.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SifraHash { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string? Grad { get; set; }
        public string Uloga { get; set; } = "klijent";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Majstor? MajstorProfil { get; set; }
    }
}
