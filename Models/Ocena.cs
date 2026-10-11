namespace eMajstor.API.Models
{
    public class Ocena
    {
        public int Id { get; set; }
        public int ZahtevId { get; set; }
        public Zahtev? Zahtev { get; set; }

        public int KlijentId { get; set; }
        public User? Klijent { get; set; }

        public int MajstorId { get; set; }
        public User? Majstor { get; set; }

        public int OcenaVrednost { get; set; } // 1 do 5
        public string? Komentar { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}