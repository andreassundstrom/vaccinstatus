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
    public class FörbrukningController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public FörbrukningController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Förbrukning
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Förbrukning>>> GetFörbrukning()
        {
            return await _context.Förbrukning.Include(p => p.Leverantör).Include(p => p.Vårdgivare).ToListAsync();
        }

        // GET: api/Förbrukning/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Förbrukning>> GetFörbrukning(int id)
        {
            var förbrukning = await _context.Förbrukning.FindAsync(id);

            if (förbrukning == null)
            {
                return NotFound();
            }

            return förbrukning;
        }

        // PUT: api/Förbrukning/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFörbrukning(int id, Förbrukning förbrukning)
        {
            if (id != förbrukning.FörbrukningId)
            {
                return BadRequest();
            }

            _context.Entry(förbrukning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FörbrukningExists(id))
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

        // POST: api/Förbrukning
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Förbrukning>> PostFörbrukning(Förbrukning förbrukning)
        {
            _context.Förbrukning.Add(förbrukning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFörbrukning", new { id = förbrukning.FörbrukningId }, förbrukning);
        }

        // DELETE: api/Förbrukning/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFörbrukning(int id)
        {
            var förbrukning = await _context.Förbrukning.FindAsync(id);
            if (förbrukning == null)
            {
                return NotFound();
            }

            _context.Förbrukning.Remove(förbrukning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FörbrukningExists(int id)
        {
            return _context.Förbrukning.Any(e => e.FörbrukningId == id);
        }
    }
}
