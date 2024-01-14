using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMediiProgramare.Data;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Pages.Masini
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
        ViewData["CategorieID"] = new SelectList(_context.Categorie, "ID", "Nume");
        ViewData["LocatieID"] = new SelectList(_context.Locatie, "ID", "Oras");
        ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Masina == null || Masina == null)
            {
                return Page();
            }

            _context.Masina.Add(Masina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
