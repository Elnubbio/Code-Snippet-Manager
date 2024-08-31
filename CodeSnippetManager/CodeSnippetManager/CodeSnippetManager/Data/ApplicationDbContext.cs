using CodeSnippetManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetManager.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
	
	public DbSet<Snippet> Snippets { get; set; }
}