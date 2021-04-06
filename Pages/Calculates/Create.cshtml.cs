using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzbuzzWeb.Data;
using FizzbuzzWeb.Models;

namespace FizzbuzzWeb.Pages.Calculates
{
    public class CreateModel : PageModel
    {
        private readonly FizzbuzzWeb.Data.CalculateContext _context;

        public CreateModel(FizzbuzzWeb.Data.CalculateContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Calculate Calculate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Calculates.Add(Calculate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
