using Microsoft.AspNetCore.Mvc;
using CodeSnippetManager.Data;
using CodeSnippetManager.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CodeSnippetManager.Controllers
{
    [ApiController]
    [Route("Snippets")]

    public class SnippetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SnippetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Snippet snippet)
        {
            snippet.VisitedCount = 1;
            snippet.CreatedOn = DateTime.UtcNow;
            if (snippet.Tags != null) {
                foreach (Tag tag in snippet.Tags)
                {
                    _context.Tags.Attach(tag);
                }
            }
            await _context.Snippets.AddAsync(snippet);
            await _context.SaveChangesAsync();
            return Ok(snippet.Content);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var snippet = new Snippet() { Id = id };
            _context.Snippets.Attach(snippet);
            _context.Snippets.Remove(snippet);
            await _context.SaveChangesAsync();
            return Ok("Successfully Deleted");
        }

        [HttpPost("Get")]
        public async Task<IActionResult> Get([FromBody] int id)
        {
            var snippet = await _context.Snippets.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(snippet);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Snippets.Include(snippy => snippy.Tags).ToListAsync());
        }
    }
}