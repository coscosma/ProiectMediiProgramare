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
    public class DetailsModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public DetailsModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Masina == null)
            {
                return NotFound();
            }

            // Include related entities
            var masina = await _context.Masina
                .Include(m => m.Producator)
                .Include(m => m.Categorie)
                .Include(m => m.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (masina == null)
            {
                return NotFound();
            }
            else
            {
                Masina = masina;
            }
            return Page();
        }

    }
}
