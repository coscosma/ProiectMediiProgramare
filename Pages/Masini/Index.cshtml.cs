using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMediiProgramare.Data;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Pages.Masini
{
    
    public class IndexModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;
        public IndexModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<Masina> Masina { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Masina.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(m => m.Model.Contains(SearchString));
            }

            Masina = await query
                .Include(m => m.Categorie)
                .Include(m => m.Locatie)
                .Include(m => m.Producator)
                .ToListAsync();
        }

        
    }
}
