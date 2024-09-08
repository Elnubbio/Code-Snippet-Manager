using System.Text.Json.Serialization;

namespace CodeSnippetManager.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string? Colour { get; set; }
        [JsonIgnore]
        public virtual List<Snippet>? Snippets { get; set; }
    }
}
