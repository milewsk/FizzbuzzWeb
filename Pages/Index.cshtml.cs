using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzbuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzbuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public Calculate Calculate { get; set; }

    //lista statyczna (aby się nie nadpisywała) int-numer string- result(sst), Datatime -czas

        public static List<(int, string, DateTime)> List_of_calc = new List<(int, string,DateTime)>(15); 

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Calculate.Result = Calculate.ResultFF();
                Calculate.Time = DateTime.Now;
                List_of_calc.Add((Calculate.Number,Calculate.Result, Calculate.Time));
                HttpContext.Session.SetString("SessionKey", JsonConvert.SerializeObject(List_of_calc));
                return Page(); 
            }

            return Page();
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
