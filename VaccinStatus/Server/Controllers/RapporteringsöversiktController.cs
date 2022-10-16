using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinStatus.Server.Database;
using VaccinStatus.Shared;
using VaccinStatus.Shared.Statistik;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinStatus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RapporteringsöversiktController : ControllerBase
    {
        private readonly VaccinStatusContext _context;

        public RapporteringsöversiktController(VaccinStatusContext context)
        {
            _context = context;
        }

        // GET: api/Rapporteringsöversikt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rapporteringsöversikt>>> GetRapporteringsöversikt()
        {
            return await _context.Rapporteringsöversikt.ToListAsync();
        }
        [HttpGet("kapacitetsstatus")]
        public async Task<ActionResult<IEnumerable<Kapacitetsstatus>>> GetKapacitetsstatus()
        {
            return await _context.Kapacitetsstatus.ToListAsync();
        }

    }
}
