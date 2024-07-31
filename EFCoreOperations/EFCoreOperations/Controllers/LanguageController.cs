using EFCoreOperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperations.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LanguageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguage()
        {
            var result = await (from language in _context.Languages
                select language).ToListAsync();
            return Ok(result);
        }
    }
}
