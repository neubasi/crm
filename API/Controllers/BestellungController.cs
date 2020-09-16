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
        public async Task<ActionResult<IEnumerable<BestellungDTO>>> GetBestellung()
        {
            // return await _context.Bestellung.ToListAsync();

         
            
            var bestellung = await _context.Bestellung.Select(t => 
            new BestellungDTO()
                       {
                           Id = t.Id,
                           Text = t.Text,
                           ArtikelId = t.ArtikelId,
                           ArtikelText = t.ArtikelNavigation.Name,
                           KundeId = t.KundeId,
                           KundeText = t.KundeNavigation.Name,
                           Menge = t.Menge,
                           Betrag = t.Betrag

            }).ToListAsync();
        
        

            return bestellung;
        }

     
        public async Task<string> getArtikelText(long id)
        {
            var artikel = await _context.Artikel.FindAsync(id);

            Console.WriteLine(artikel.Name);
           
            return artikel.Name;
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
            
            var artikel = await _context.Artikel.FindAsync(bestellung.ArtikelId);
            var artikelPreis = artikel.Preis;

            var bestellung_modified = new Bestellung()
            {
                Text = bestellung.Text,
                ArtikelId = bestellung.ArtikelId,
                KundeId = bestellung.KundeId,
                Menge = bestellung.Menge,
                Betrag = bestellung.calculateTotal(artikelPreis, bestellung.Menge)
            };

            _context.Bestellung.Add(bestellung_modified);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBestellung", new { id = bestellung_modified.Id }, bestellung_modified);
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
