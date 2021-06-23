using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirAstana.Models;

namespace AirAstana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FlightsController(ApplicationContext context)
        {
            _context = context;
            if (!_context.Flights.Any())
            {
                _context.Flights.Add(new Flights { 
                    From = _context.Cities.FirstOrDefault(c => c.name == "Almaty"), 
                    To = _context.Cities.FirstOrDefault(c=>c.name== "Shymkent"), 
                    DepartureDate = new DateTime(2021,6,20),
                    ArrivedDate = new DateTime(2021,6,21)
                    });
                _context.Flights.Add(new Flights
                {
                    From = _context.Cities.FirstOrDefault(c => c.name == "Almaty"),
                    To = _context.Cities.FirstOrDefault(c => c.name == "Moscow"),
                    DepartureDate = new DateTime(2021, 6, 21),
                    ArrivedDate = new DateTime(2021, 6, 23)
                });
                _context.Flights.Add(new Flights
                {
                    From = _context.Cities.FirstOrDefault(c => c.name == "Moscow"),
                    To = _context.Cities.FirstOrDefault(c => c.name == "Almaty"),
                    DepartureDate = new DateTime(2021, 6, 20),
                    ArrivedDate = new DateTime(2021, 6, 22)
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Flights
        [HttpGet]
        public string GetFlights()
        {
            string json = "[";
            List<Flights> flights = _context.Flights.OrderBy(f=> f.DepartureDate).ToList();
            try
            {
                string delay="";
                foreach (var flight in flights)
                {
                    /*delay = _context.Delays.FirstOrDefault(f => f.FlightsId == flight.Id) != null ? _context.Delays.FirstOrDefault(f => f.FlightsId == flight.Id).Delay : "No delay";*/
                    json += "{\"id\": \"" + flight.Id + "\"," +
                        "\"from\": \"" + _context.Cities.FirstOrDefault(c => c.Id == flight.FromId).name + "\"," +
                        "\"to\": \"" + _context.Cities.FirstOrDefault(c => c.Id == flight.ToId).name + "\"," +
                        "\"DepartureDate\":\"" + flight.DepartureDate.Date + "\"," +
                        "\"ArrivedDate\": \"" + flight.ArrivedDate.Date + "\"" +
                       /* "," +
                        "\"Delays\": \""+ delay + "\"" +*/
                        "},";
                }
            }
            catch(Exception e)
            {
                
            }
            
            json = json.Length <= 1 ? "[" : json.Substring(0, json.Length - 1);
            json += "]";
            return json;
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flights>> GetFlights(int id)
        {
            var flights = await _context.Flights.FindAsync(id);

            if (flights == null)
            {
                return NotFound();
            }

            return flights;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlights(int id, Flights flights)
        {
            if (id != flights.Id)
            {
                return BadRequest();
            }

            _context.Entry(flights).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flights>> PostFlights(Flights flights)
        {
            _context.Flights.Add(flights);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlights", new { id = flights.Id }, flights);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flights>> DeleteFlights(int id)
        {
            var flights = await _context.Flights.FindAsync(id);
            if (flights == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flights);
            await _context.SaveChangesAsync();

            return flights;
        }

        private bool FlightsExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
