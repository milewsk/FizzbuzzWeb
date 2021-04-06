using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzbuzzWeb.Data;
using FizzbuzzWeb.Models;

namespace FizzbuzzWeb.Pages.Calculates
{
    public class EditModel : PageModel
    {
        private readonly FizzbuzzWeb.Data.CalculateContext _context;

        public EditModel(FizzbuzzWeb.Data.CalculateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calculate Calculate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calculate = await _context.Calculates.FirstOrDefaultAsync(m => m.Id == id);

            if (Calculate == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calculate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculateExists(Calculate.Id))
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

        private bool CalculateExists(int id)
        {
            return _context.Calculates.Any(e => e.Id == id);
        }
    }
}
