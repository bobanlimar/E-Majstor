namespace eMajstor.API.Models
{
    public class Zahtev
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public User? Klijent { get; set; }

        public int MajstorId { get; set; }
        public User? Majstor { get; set; }

        public string OpisKvara { get; set; } = string.Empty;
        public string Status { get; set; } = "na_cekanju";
        public DateTime DatumZahteva { get; set; } = DateTime.UtcNow;
    }
}