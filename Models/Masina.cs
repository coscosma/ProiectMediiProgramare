namespace ProiectMediiProgramare.Models
{
    public class Masina
    {
        public int ID { get; set; }
        public string Model { get; set; }

        public int? ProducatorID{ get; set; }

        public Producator? Producator { get; set; }

        public int An {  get; set; }

        public int? CategorieID { get; set; }

        public Categorie? Categorie { get; set; }

        public decimal? Pret {  get; set; }

        public int? LocatieID { get; set; }

        public Locatie? Locatie { get; set; }
    }
}
