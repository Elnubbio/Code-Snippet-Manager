using CodeSnippetManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetManager.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Snippet>()
            .HasMany<Tag>(s => s.Tags)
            .WithMany(t => t.Snippets);
    }
    public DbSet<Snippet> Snippets { get; set; }
    public DbSet<Tag> Tags { get; set; }
}