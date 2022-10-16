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
    public class KapacitetController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public KapacitetController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Kapacitets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kapacitet>>> GetKapacitet()
        {
            return await _context.Kapacitet.Include(p => p.Vårdgivare).ToListAsync();
        }

        // GET: api/Kapacitets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kapacitet>> GetKapacitet(int id)
        {
            var kapacitet = await _context.Kapacitet.FindAsync(id);

            if (kapacitet == null)
            {
                return NotFound();
            }

            return kapacitet;
        }

        // PUT: api/Kapacitets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKapacitet(int id, Kapacitet kapacitet)
        {
            if (id != kapacitet.KapacitetId)
            {
                return BadRequest();
            }

            _context.Entry(kapacitet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KapacitetExists(id))
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

        // POST: api/Kapacitets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kapacitet>> PostKapacitet(Kapacitet kapacitet)
        {
            _context.Kapacitet.Add(kapacitet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKapacitet", new { id = kapacitet.KapacitetId }, kapacitet);
        }

        // DELETE: api/Kapacitets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKapacitet(int id)
        {
            var kapacitet = await _context.Kapacitet.FindAsync(id);
            if (kapacitet == null)
            {
                return NotFound();
            }

            _context.Kapacitet.Remove(kapacitet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KapacitetExists(int id)
        {
            return _context.Kapacitet.Any(e => e.KapacitetId == id);
        }
    }
}
