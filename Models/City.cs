using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirAstana.Models
{
    public class City
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string name { get; set; }

    }
}
