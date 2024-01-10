namespace ProiectMediiProgramare.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        public ICollection<Masina>? Masini { get; set; }


    }
}
