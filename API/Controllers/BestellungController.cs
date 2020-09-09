using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Modelle;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungController : ControllerBase
    {
        private readonly Basiscontext _context;

        public BestellungController(Basiscontext context)
        {
            _context = context;
        }

        // GET: api/Bestellung
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellung>>> GetBestellung()
        {
            return await _context.Bestellung.ToListAsync();
        }

        // GET: api/Bestellung/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bestellung>> GetBestellung(long id)
        {
            var bestellung = await _context.Bestellung.FindAsync(id);

            if (bestellung == null)
            {
                return NotFound();
            }

            return bestellung;
        }

        // PUT: api/Bestellung/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellung(long id, Bestellung bestellung)
        {
            if (id != bestellung.Id)
            {
                return BadRequest();
            }

            _context.Entry(bestellung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellungExists(id))
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

        // POST: api/Bestellung
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bestellung>> PostBestellung(Bestellung bestellung)
        {
            _context.Bestellung.Add(bestellung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBestellung", new { id = bestellung.Id }, bestellung);
        }

        // DELETE: api/Bestellung/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bestellung>> DeleteBestellung(long id)
        {
            var bestellung = await _context.Bestellung.FindAsync(id);
            if (bestellung == null)
            {
                return NotFound();
            }

            _context.Bestellung.Remove(bestellung);
            await _context.SaveChangesAsync();

            return bestellung;
        }

        private bool BestellungExists(long id)
        {
            return _context.Bestellung.Any(e => e.Id == id);
        }
    }
}
