namespace eMajstor.API.Models
{
    public class Majstor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public string Kategorija { get; set; } = string.Empty;
        public string? Opis { get; set; }
        public decimal? CenaPoSatu { get; set; }
    }
}
