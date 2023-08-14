using System.ComponentModel.DataAnnotations;

namespace BlogApp.Domain;

public class Comment : BaseEntity
{
    [Key]
    public int CommentId { get; set; }
    public string Text { get; set; }
}