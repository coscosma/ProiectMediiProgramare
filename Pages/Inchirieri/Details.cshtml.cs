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
    public class DetailsModel : PageModel
    {
        private readonly ProiectMediiProgramare.Data.ApplicationDbContext _context;

        public DetailsModel(ProiectMediiProgramare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Inchiriere Inchiriere { get; set; } = default!; 

       
            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _context.Inchiriere == null)
                {
                    return NotFound();
                }

                // Modify the query to include Masina and its Producator
                var inchiriere = await _context.Inchiriere
                    .Include(i => i.Masina)
                        .ThenInclude(m => m.Producator)
                    .Include(i => i.Client) // Assuming you also want to include details about the Client
                    .FirstOrDefaultAsync(m => m.ID == id);

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

        }
    }

