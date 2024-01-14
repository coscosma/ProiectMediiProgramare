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
    public class IndexModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public IndexModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Inchiriere> Inchiriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inchiriere != null)
            {
                Inchiriere = await _context.Inchiriere
                .Include(i => i.Client)
                .Include(i => i.Masina)
                  .ThenInclude(m => m.Producator).
                ToListAsync();
            }
        }
    }
}
