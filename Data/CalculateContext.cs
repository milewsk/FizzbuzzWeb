using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzbuzzWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace FizzbuzzWeb.Data
{
    public class CalculateContext : DbContext
    {
        public DbSet<Calculate> Calculates { get; set; }

    }
}
