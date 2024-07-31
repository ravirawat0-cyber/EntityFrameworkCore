using EFCoreOperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperations.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CurrrencyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurrrencyController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            // var result = await _context.Currencies.ToListAsync();
            var result = await (from currencies in _context.Currencies
                select currencies).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCurrenciesById([FromRoute] int id)
        {
            var result = await _context.Currencies.FindAsync(id);
            return Ok(result);
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllCurrenciesNameId([FromRoute] string name,
            [FromQuery] string? description)
        {

            // var result = await _context.Currencies
            //             .Where(x => x.Title == name).
            //             FirstOrDefaultAsync();

            //performance
            //  var result = await _context.Currencies.
            //      FirstOrDefaultAsync(x => x.Title == name);

            // return immediately as when data found

            var result = await _context.Currencies.FirstOrDefaultAsync(x =>
                x.Title == name &&
                (string.IsNullOrEmpty(description)
                 || x.Description == description));

            return Ok(result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetCurrencyByIdsAsync([FromBody] List<int> ids)
        {
           // var ids = new List<int> { 1, 2, 3 };
            var result = await _context.Currencies.
                Where(x => ids.Contains(x.Id))
                .Select(x => new Currencies()
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToListAsync(); 

            return Ok(result);
        }
    }
}
