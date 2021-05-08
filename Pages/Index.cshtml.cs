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
using FizzbuzzWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace FizzbuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        [BindProperty(SupportsGet = true)]
        public Calculate Calculate { get; set; }

        private readonly CalculateContext _contextCalculate;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        //lista statyczna (aby się nie nadpisywała) int-numer string- result(sst), Datatime -czas

        public static List<(int, string, DateTime)> List_of_calc = new List<(int, string,DateTime)>(15);

        public IList<Calculate> Calculates { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //sesja
                Calculate.Result = Calculate.ResultFF();
                Calculate.Time = DateTime.Now;
                List_of_calc.Add((Calculate.Number,Calculate.Result, Calculate.Time));
                HttpContext.Session.SetString("SessionKey", JsonConvert.SerializeObject(List_of_calc));

                //dodanie elementu nowego do bazy

                if (_signInManager.IsSignedIn(User)) {

                    Calculate.user = 

                    _contextCalculate.Calculates.Add(Calculate);
                    _contextCalculate.SaveChanges();

                }

               
             
               


                return Page(); 
            }

            return Page();
        }

        public IndexModel(ILogger<IndexModel> logger, CalculateContext context,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _contextCalculate = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
            var Calculate_list_DB = from calc in _contextCalculate.Calculates select calc;
            Calculates = Calculate_list_DB.ToList();

        }
    }
}
