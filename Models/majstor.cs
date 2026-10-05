namespace eMajstor.API.Models
{
    public class Majstor
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string Zanimanje { get; set; } = string.Empty;
        public string BrojTelefona { get; set; } = string.Empty;
        public string Grad { get; set; } = string.Empty;
        public decimal CenaPoSatu { get; set; }
    }
}
