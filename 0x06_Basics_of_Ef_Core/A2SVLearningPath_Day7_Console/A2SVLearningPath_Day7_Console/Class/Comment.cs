using System.ComponentModel.DataAnnotations;

namespace A2SVLearningPath_Day7_Console.Class;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Post? Post { get; set; }
}