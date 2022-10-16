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
    public class LagersaldoController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public LagersaldoController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Lagersaldo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lagersaldo>>> GetLagersaldo()
        {
            return await _context
                .Lagersaldo.Include(p => p.Leverantör)
                .Include(p => p.Vårdgivare)
                .ToListAsync();
        }

        // GET: api/Lagersaldo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lagersaldo>> GetLagersaldo(int id)
        {
            var lagersaldo = await _context.Lagersaldo.FindAsync(id);

            if (lagersaldo == null)
            {
                return NotFound();
            }

            return lagersaldo;
        }

        // PUT: api/Lagersaldo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLagersaldo(int id, Lagersaldo lagersaldo)
        {
            if (id != lagersaldo.LagersaldoId)
            {
                return BadRequest();
            }

            _context.Entry(lagersaldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LagersaldoExists(id))
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

        // POST: api/Lagersaldo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lagersaldo>> PostLagersaldo(Lagersaldo lagersaldo)
        {
            _context.Lagersaldo.Add(lagersaldo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLagersaldo", new { id = lagersaldo.LagersaldoId }, lagersaldo);
        }

        // DELETE: api/Lagersaldo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLagersaldo(int id)
        {
            var lagersaldo = await _context.Lagersaldo.FindAsync(id);
            if (lagersaldo == null)
            {
                return NotFound();
            }

            _context.Lagersaldo.Remove(lagersaldo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LagersaldoExists(int id)
        {
            return _context.Lagersaldo.Any(e => e.LagersaldoId == id);
        }
    }
}
