namespace eMajstor.API.Models
{
    public class Usluga
    {
        public int Id { get; set; }
        public int MajstorId { get; set; }
        public Majstor? Majstor { get; set; }

        public string NazivUsluge { get; set; } = string.Empty;
        public string? Opis { get; set; }
        public decimal? Cena { get; set; }
    }
}