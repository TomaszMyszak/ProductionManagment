using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionManagment.Models;

namespace ProductionManagment.Data
{
    public class ProductionManagmentContext : DbContext
    {
        public ProductionManagmentContext (DbContextOptions<ProductionManagmentContext> options)
            : base(options)
        {
        }

        public DbSet<ProductionManagment.Models.City>? City { get; set; }

        public DbSet<ProductionManagment.Models.Module>? Module { get; set; }

        public DbSet<ProductionManagment.Models.SearchHistory>? SearchHistory { get; set; }
    }
}
