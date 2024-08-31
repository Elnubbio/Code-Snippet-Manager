using Microsoft.AspNetCore.Mvc;
using CodeSnippetManager.Data;
using CodeSnippetManager.Data.Models;

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

        [HttpPost]
        public IActionResult Get([FromBody] Snippet snippet) 
        {
            return Ok(snippet.Content);
        }

    }
}