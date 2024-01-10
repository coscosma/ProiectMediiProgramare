namespace ProiectMediiProgramare.Models
{
    public class Locatie
    {

        public int ID { get; set; }

        public string Oras { get; set; }

        public ICollection <Masina>? Masini {  get; set; }
        

    }
}
