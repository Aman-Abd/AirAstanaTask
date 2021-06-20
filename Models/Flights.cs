using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirAstana.Models
{
    public class Flights
    {
        public int Id { get; set; }
        public City From { get; set; }
        public City To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivedDate { get; set; }
    }
}
