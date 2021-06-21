using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirAstana.Models
{
    public class Delays
    {
        public int Id { get; set; }

        public string Delay { get; set; }
        public int FlightsId { get; set; }
        public Flights Flights { get; set; }
    }
}
