using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ProductionManagment.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext()
            : base("name=ConnectionString") { }

        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }
    }


    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double TransportCost { get; set; }

        public double CostOfWorkingHour { get; set; }

        public virtual SearchHistory SearchHistory { get; set; }
    }


    public class Module
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double AssemblyTime { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public virtual SearchHistory SearchHistory { get; set; }
    }


    public class SearchHistory
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string ModuleName1 { get; set; }

        public string ModuleName2 { get; set; }

        public string ModuleName3 { get; set; }

        public string ModuleName4 { get; set; }

        public double ProductionCost { get; set; }
    }
}
