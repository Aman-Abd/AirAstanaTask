using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirAstana.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<City> Cities { get; set; }
    }
}
