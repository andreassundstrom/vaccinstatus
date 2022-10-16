using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinStatus.Server.Database;
using VaccinStatus.Shared;

namespace VaccinStatus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeställningController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public BeställningController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Beställning
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beställning>>> GetBeställning()
        {
            return await _context.Beställning.Include(p => p.Vårdgivare).ToListAsync();
        }

        // GET: api/Beställning/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beställning>> GetBeställning(int id)
        {
            var beställning = await _context.Beställning.FindAsync(id);

            if (beställning == null)
            {
                return NotFound();
            }

            return beställning;
        }

        // PUT: api/Beställning/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeställning(int id, Beställning beställning)
        {
            if (id != beställning.BeställningId)
            {
                return BadRequest();
            }

            _context.Entry(beställning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeställningExists(id))
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

        // POST: api/Beställning
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beställning>> PostBeställning(Beställning beställning)
        {
            _context.Beställning.Add(beställning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeställning", new { id = beställning.BeställningId }, beställning);
        }

        // DELETE: api/Beställning/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeställning(int id)
        {
            var beställning = await _context.Beställning.FindAsync(id);
            if (beställning == null)
            {
                return NotFound();
            }

            _context.Beställning.Remove(beställning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeställningExists(int id)
        {
            return _context.Beställning.Any(e => e.BeställningId == id);
        }
    }
}
