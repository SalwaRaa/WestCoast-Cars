using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/valuations")]
    public class ValuationsController : ControllerBase
    {
        private readonly CosmosContext _context;
        public ValuationsController(CosmosContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetById()
        {
            var valuations = await _context.Valuations.ToListAsync();
            return Ok(valuations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var valuation = await _context.Valuations.SingleOrDefaultAsync(v => v.Id == id);
            return Ok(valuation);
        }

        [HttpGet("bymake/{make}")]
        public async Task<IActionResult> GetByMake(string make)
        {
            var valuations = await _context.Valuations.Where(v => v.Vehicle.Make == make).ToListAsync();
            return Ok(valuations);
        }

        [HttpGet("byregno/{regNo}")]
        public async Task<IActionResult> GetByRegNo(string regNo)
        {
            var valuation = await _context.Valuations.SingleOrDefaultAsync(v => v.Vehicle.RegistrationNo == regNo);
            return Ok(valuation);
        }
    }
}