using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzbuzzWeb.Data;
using FizzbuzzWeb.Models;

namespace FizzbuzzWeb.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CalculateContext _context;

        public DeleteModel(CalculateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calculate Calculate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //b³¹d z przekazanym numerem
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                //szukanie podanego id w bazie
                Calculate = await _context.Calculates.FindAsync(keyValues: id);

                //jeœli jakimœ  cudem nie istnieje
                if(Calculate == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        { 
            if(id == null)
            { 
                return NotFound(); 
            }

            Calculate = await _context.Calculates.FindAsync(id);

            if (Calculate != null)
            {
                _context.Calculates.Remove(Calculate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Ostatnie");
        }

    }
}
