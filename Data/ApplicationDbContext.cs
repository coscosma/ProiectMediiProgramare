using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProiectMediiProgramare.Models.Categorie>? Categorie { get; set; }
        public DbSet<ProiectMediiProgramare.Models.Client>? Client { get; set; }
        public DbSet<ProiectMediiProgramare.Models.Inchiriere>? Inchiriere { get; set; }
        public DbSet<ProiectMediiProgramare.Models.Locatie>? Locatie { get; set; }
        public DbSet<ProiectMediiProgramare.Models.Masina>? Masina { get; set; }
        public DbSet<ProiectMediiProgramare.Models.Producator>? Producator { get; set; }
    }
}