using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzbuzzWeb.Data;
using FizzbuzzWeb.Models;

namespace FizzbuzzWeb.Pages.Calculates
{
    public class DetailsModel : PageModel
    {
        private readonly FizzbuzzWeb.Data.CalculateContext _context;

        public DetailsModel(FizzbuzzWeb.Data.CalculateContext context)
        {
            _context = context;
        }

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
    }
}
