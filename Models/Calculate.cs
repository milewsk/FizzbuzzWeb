using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FizzbuzzWeb.Areas.Identity.Data;

namespace FizzbuzzWeb.Models
{
    public class Calculate

    {
        public int Id { get; set; }

        [Range(1,1000, ErrorMessage ="Podaj liczbe z przedziału [1...1000]")]
        public int Number { get; set; }
     
        public string Result { get; set; }
     
        public DateTime Time { get; set; }

        // string alb indentyuser
        public ApplicationUser user { get; set; }

        public string ResultFF()
        {
            string sst = "";

            if (Number > 0 && Number % 3 == 0)
            { sst = "Fizz"; }
            
            if (Number > 0 && Number % 5 == 0)
            { sst = "Buzz"; }
             
            if (Number > 0 && Number % 5 == 0 && Number % 3 == 0) 
            { sst = "Fizzbuzz"; }

            return sst;
        }
    }
}
