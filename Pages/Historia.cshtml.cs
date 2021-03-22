using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzbuzzWeb.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace FizzbuzzWeb.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;

        public Calculate calculate;

        // Kolejny raz tworzę listę do przechowywania danych pomiędzy przesyłem post-get
        public static List<(int, string, DateTime)> myList = new List<(int, string, DateTime)>(15);

        public HistoriaModel(ILogger<HistoriaModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var SessionKey = HttpContext.Session.GetString("SessionKey");
            if (SessionKey != null)
            {
               myList = JsonConvert.DeserializeObject<List<(int, string, DateTime)>>(SessionKey);
            }
        }
    }
}
