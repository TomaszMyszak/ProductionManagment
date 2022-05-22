using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProductionManagment.Models;

namespace ProductionManagment.DAL
{
    public class CalculatorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CalculatorContext>
    {
        protected override void Seed(CalculatorContext context)
            var citys = new List<City>
            {
                new citys{Id="1", Name="Tarnowskie Góry", TransportCost="100", CostOfWorkingHour ="120"},
                new citys{Id="2", Name="Katowice", TransportCost="110", CostOfWorkingHour ="140"},
                new citys{Id="3", Name="Glwice", TransportCost="150", CostOfWorkingHour ="120"},
                new citys{Id="4", Name="Warszawa", TransportCost="200", CostOfWorkingHour ="180"},
                new citys{Id="5", Name="Poznań", TransportCost="250", CostOfWorkingHour ="100"},
                new citys{Id="6", Name="Szczeciń", TransportCost="300", CostOfWorkingHour ="250"},
                new citys{Id="7", Name="Lublin", TransportCost="280", CostOfWorkingHour ="80"},
            };

            citys.ForEach(s => context.City.Add(s));
            context.SaveChanges();

            var Modules = new List<Module>
            {
                new Modules{ Id = " 1"}
            }
    }
}
