using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMediiProgramare.Data;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Pages.Inchirieri
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public DeleteModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inchiriere Inchiriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere = await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);

            if (inchiriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inchiriere = inchiriere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }
            var inchiriere = await _context.Inchiriere.FindAsync(id);

            if (inchiriere != null)
            {
                Inchiriere = inchiriere;
                _context.Inchiriere.Remove(Inchiriere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
