using System.ComponentModel.DataAnnotations;

namespace A2SVLearningPath_Day7_Console.Class;

public class Post
{
    [Key]
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Comment>? Comments { get; set; }
}