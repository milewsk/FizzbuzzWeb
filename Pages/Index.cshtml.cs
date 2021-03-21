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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Calculate.Calc(Calculate.Number);
                HttpContext.Session.SetString("SessionKey", JsonConvert.SerializeObject(Calculate));
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
