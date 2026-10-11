namespace eMajstor.API.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public int PosiljalacId { get; set; }
        public User? Posiljalac { get; set; }

        public int PrimalacId { get; set; }
        public User? Primalac { get; set; }

        public string TekstPoruke { get; set; } = string.Empty;
        public DateTime PoslatoAt { get; set; } = DateTime.UtcNow;
    }
}
