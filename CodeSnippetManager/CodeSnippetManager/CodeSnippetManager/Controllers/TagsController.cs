using Microsoft.AspNetCore.Mvc;
using CodeSnippetManager.Data;
using CodeSnippetManager.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Azure;

namespace CodeSnippetManager.Controllers
{
    [ApiController]
    [Route("Tags")]

    public class TagsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Tag tag) 
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return Ok(tag.Name);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var tag = new Tag() { Id = id };
            _context.Tags.Attach(tag);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return Ok("Successfully Deleted");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Tags.ToListAsync());
        }
    }
}