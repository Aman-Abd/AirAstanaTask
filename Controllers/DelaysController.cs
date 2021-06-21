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
    public class DelaysController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DelaysController(ApplicationContext context)
        {
            _context = context;
            if (!_context.Delays.Any())
            {
                _context.Delays.Add(new Delays { Delay = "1 hour", Flights = _context.Flights.FirstOrDefault() });
                _context.SaveChanges();
            }
        }

        // GET: api/Delays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delays>>> GetDelays()
        {
            return await _context.Delays.ToListAsync();
        }

        // GET: api/Delays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delays>> GetDelays(int id)
        {
            var delays = await _context.Delays.FindAsync(id);

            if (delays == null)
            {
                return NotFound();
            }

            return delays;
        }

        // PUT: api/Delays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelays(int id, Delays delays)
        {
            if (id != delays.Id)
            {
                return BadRequest();
            }

            _context.Entry(delays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DelaysExists(id))
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

        // POST: api/Delays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Delays>> PostDelays(Delays delays)
        {
            _context.Delays.Add(delays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDelays", new { id = delays.Id }, delays);
        }

        // DELETE: api/Delays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Delays>> DeleteDelays(int id)
        {
            var delays = await _context.Delays.FindAsync(id);
            if (delays == null)
            {
                return NotFound();
            }

            _context.Delays.Remove(delays);
            await _context.SaveChangesAsync();

            return delays;
        }

        private bool DelaysExists(int id)
        {
            return _context.Delays.Any(e => e.Id == id);
        }
    }
}
