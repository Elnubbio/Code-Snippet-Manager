using System.Net.Mime;

namespace CodeSnippetManager.Data.Models;

public class Snippet
{
	public int Id { get; set; }
	public string Content { get; set; }
	public int VisitedCount { get; set; }
	public DateTime CreatedOn { get; set; }
	public virtual IEnumerable<Tag>? Tags { get; set; }
}