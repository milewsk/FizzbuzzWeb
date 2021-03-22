using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzbuzzWeb.Models
{
    public class Calculate
    {
       public string result;

        public Calculate()
        {
            this.Time = DateTime.Now;
            this.Number = Number;  
        }

        [Range(1,1000, ErrorMessage ="Podaj liczbe z przedziału [1...1000]")]
        public int Number { get; set; }

        public DateTime Time { get; set; }

        public string Result { get; set; }
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
