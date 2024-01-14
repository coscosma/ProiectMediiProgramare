using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMediiProgramare.Data;
using ProiectMediiProgramare.Models;

namespace ProiectMediiProgramare.Pages.Masini
{
    public class EditModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public EditModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Masina == null)
            {
                return NotFound();
            }

            var masina =  await _context.Masina.FirstOrDefaultAsync(m => m.ID == id);
            if (masina == null)
            {
                return NotFound();
            }
            Masina = masina;
           ViewData["CategorieID"] = new SelectList(_context.Categorie, "ID", "Nume");
           ViewData["LocatieID"] = new SelectList(_context.Locatie, "ID", "Oras");
           ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Masina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasinaExists(Masina.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasinaExists(int id)
        {
          return (_context.Masina?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
