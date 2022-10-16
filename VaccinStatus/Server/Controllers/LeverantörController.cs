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
    public class LeverantörController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public LeverantörController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Leverantör
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leverantör>>> GetLeverantörer()
        {
            return await _context.Leverantörer.ToListAsync();
        }

        // GET: api/Leverantör/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leverantör>> GetLeverantör(int id)
        {
            var leverantör = await _context.Leverantörer.FindAsync(id);

            if (leverantör == null)
            {
                return NotFound();
            }

            return leverantör;
        }

        // PUT: api/Leverantör/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeverantör(int id, Leverantör leverantör)
        {
            if (id != leverantör.LeverantörId)
            {
                return BadRequest();
            }

            _context.Entry(leverantör).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeverantörExists(id))
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

        // POST: api/Leverantör
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Leverantör>> PostLeverantör(Leverantör leverantör)
        {
            _context.Leverantörer.Add(leverantör);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeverantör", new { id = leverantör.LeverantörId }, leverantör);
        }

        // DELETE: api/Leverantör/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeverantör(int id)
        {
            var leverantör = await _context.Leverantörer.FindAsync(id);
            if (leverantör == null)
            {
                return NotFound();
            }

            _context.Leverantörer.Remove(leverantör);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeverantörExists(int id)
        {
            return _context.Leverantörer.Any(e => e.LeverantörId == id);
        }
    }
}
