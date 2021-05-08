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
using FizzbuzzWeb.Areas.Identity.Data;

namespace FizzbuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        [BindProperty(SupportsGet = true)]
        public Calculate Calculate { get; set; }

        private readonly CalculateContext _contextCalculate;

        private  UserManager<ApplicationUser> _userManager;

        private  SignInManager<ApplicationUser> _signInManager;

        //lista statyczna (aby się nie nadpisywała) int-numer string- result(sst), Datatime -czas

        public static List<(int, string, DateTime, string)> List_of_calc = new List<(int, string,DateTime, string)>(15);

        public IList<Calculate> Calculates { get; set; }


        public IndexModel(ILogger<IndexModel> logger, CalculateContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _contextCalculate = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //sesja
                Calculate.Result = Calculate.ResultFF();
                Calculate.Time = DateTime.Now;
                Calculate.UserName = "";

                //dodanie elementu nowego do bazy

                if (_signInManager.IsSignedIn(User)) {

                    Calculate.UserName = User.Identity.Name.ToString();
                    _contextCalculate.Calculates.Add(Calculate);
                    _contextCalculate.SaveChanges();

                }

                List_of_calc.Add((Calculate.Number, Calculate.Result, Calculate.Time,Calculate.UserName));
                HttpContext.Session.SetString("SessionKey", JsonConvert.SerializeObject(List_of_calc));




                return Page(); 
            }

            return Page();
        }

       

        public void OnGet()
        {
            var Calculate_list_DB = from calc in _contextCalculate.Calculates select calc;
            Calculates = Calculate_list_DB.ToList();

        }
    }
}
