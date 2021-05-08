using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzbuzzWeb.Areas.Identity.Data;
using FizzbuzzWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FizzbuzzWeb.Data
{
    public class CalculateContext : IdentityDbContext<ApplicationUser>
    {
        public CalculateContext(DbContextOptions options) : base(options) { }

        public DbSet<Calculate> Calculates { get; set; }

    }
}
