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
    public class VårdgivareController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public VårdgivareController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Vårdgivare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vårdgivare>>> GetVårdgivare()
        {
            return await _context.Vårdgivare.ToListAsync();
        }

        // GET: api/Vårdgivare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vårdgivare>> GetVårdgivare(int id)
        {
            var vårdgivare = await _context.Vårdgivare.FindAsync(id);

            if (vårdgivare == null)
            {
                return NotFound();
            }

            return vårdgivare;
        }

        // PUT: api/Vårdgivare/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVårdgivare(int id, Vårdgivare vårdgivare)
        {
            if (id != vårdgivare.VårdgivareId)
            {
                return BadRequest();
            }

            _context.Entry(vårdgivare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VårdgivareExists(id))
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

        // POST: api/Vårdgivare
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vårdgivare>> PostVårdgivare(Vårdgivare vårdgivare)
        {
            _context.Vårdgivare.Add(vårdgivare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVårdgivare", new { id = vårdgivare.VårdgivareId }, vårdgivare);
        }

        // DELETE: api/Vårdgivare/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVårdgivare(int id)
        {
            var vårdgivare = await _context.Vårdgivare.FindAsync(id);
            if (vårdgivare == null)
            {
                return NotFound();
            }

            _context.Vårdgivare.Remove(vårdgivare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VårdgivareExists(int id)
        {
            return _context.Vårdgivare.Any(e => e.VårdgivareId == id);
        }
    }
}
