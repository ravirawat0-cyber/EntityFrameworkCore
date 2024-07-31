using EFCoreOperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperations.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookPricesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookPricesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await (from bookPrices in _context.BookPrices
                                select bookPrices).ToListAsync();

            return Ok(result);
        }
    }
}
