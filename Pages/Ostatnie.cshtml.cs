using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzbuzzWeb.Data;
using Microsoft.EntityFrameworkCore;
using FizzbuzzWeb.Models;

namespace FizzbuzzWeb.Pages
{
    public class OstatnieModel : PageModel
    {
        // po³¹czenie contextu 
        private readonly CalculateContext _context;

       // public int iteration = 0;

        public IList<Calculate> Calculates { get; set; }

        public OstatnieModel(CalculateContext context)
        {
            _context = context;
        }




        public void OnGet()
        {
            var Query = (from calc in _context.Calculates  orderby calc.Time descending  select calc).Take(10);

           // var tenLatest_Query = Query.Take(10);

            Calculates = Query.ToList();

           

        }
    }
}
