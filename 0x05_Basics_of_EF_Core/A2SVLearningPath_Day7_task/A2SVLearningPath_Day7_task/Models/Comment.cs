using System.ComponentModel.DataAnnotations;

namespace A2SVLearningPath_Day7_task.Models;

public class Comment
{
 [Key]
 public int CommentId { get; set; }
 public int PostId { get; set; }
 public string Text { get; set; }
 public DateTime CreatedAt { get; set; }
 // public Post? Post { get; set; } = null!;
}
