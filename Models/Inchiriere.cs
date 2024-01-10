namespace ProiectMediiProgramare.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }

        public Client? Client { get; set; }

        public int? MasinaID { get; set; }

        public Masina? Masina { get; set; }

        public DateTime DataProgramarii { get; set; }

    }
}
