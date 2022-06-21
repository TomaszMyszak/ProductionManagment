using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProductionManagment.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modules { get; set; }
        public double Cost { get; set; }
        public virtual Module Module { get; set; }    
        
    }
}
