namespace ProiectMediiProgramare.Models
{
    public class Client
    {

        public int ID { get; set; }
        public string Nume { get; set; }

        public string? Adresa { get; set; }

        public string? Email { get; set; }

        public string? NumarTel { get; set; }

        public ICollection<Inchiriere>? Inchirieri { get; set; }







    }

}
