using Microsoft.AspNetCore.Mvc;
using CodeSnippetManager.Data;

namespace CodeSnippetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SnippetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SnippetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("Okay");
        }

    }
}