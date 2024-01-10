using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMediiProgramare.Data;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public CreateModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["MasinaID"] = new SelectList(_context.Set<Masina>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Inchiriere == null || Inchiriere == null)
            {
                return Page();
            }

            _context.Inchiriere.Add(Inchiriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
