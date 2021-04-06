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
    public class IndexModel : PageModel
    {
        private readonly FizzbuzzWeb.Data.CalculateContext _context;

        public IndexModel(FizzbuzzWeb.Data.CalculateContext context)
        {
            _context = context;
        }

        public IList<Calculate> Calculate { get;set; }

        public async Task OnGetAsync()
        {
            Calculate = await _context.Calculates.ToListAsync();
        }
    }
}
