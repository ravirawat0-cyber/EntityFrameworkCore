using EFCoreOperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperations.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAddBook()
        {
            var result = await (from book in _context.Books
                select book).ToListAsync();
            return Ok(result);
        }
    }
}
