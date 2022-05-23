using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductionManagment.Models
{
    public class CalculatorContext : DbContext
    {
        //  public CalculatorContext() : base('connectionString') { };


        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }


    
    }
}
