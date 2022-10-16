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
    public class InleveransController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public InleveransController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Inleverans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inleverans>>> GetInleverans()
        {
            return await _context.Inleverans.Include(p => p.Vårdgivare).ToListAsync();
        }

        // GET: api/Inleverans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inleverans>> GetInleverans(int id)
        {
            var inleverans = await _context.Inleverans.FindAsync(id);

            if (inleverans == null)
            {
                return NotFound();
            }

            return inleverans;
        }

        // PUT: api/Inleverans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInleverans(int id, Inleverans inleverans)
        {
            if (id != inleverans.InleveransId)
            {
                return BadRequest();
            }

            _context.Entry(inleverans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InleveransExists(id))
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

        // POST: api/Inleverans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inleverans>> PostInleverans(Inleverans inleverans)
        {
            _context.Inleverans.Add(inleverans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInleverans", new { id = inleverans.InleveransId }, inleverans);
        }

        // DELETE: api/Inleverans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInleverans(int id)
        {
            var inleverans = await _context.Inleverans.FindAsync(id);
            if (inleverans == null)
            {
                return NotFound();
            }

            _context.Inleverans.Remove(inleverans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InleveransExists(int id)
        {
            return _context.Inleverans.Any(e => e.InleveransId == id);
        }
    }
}
