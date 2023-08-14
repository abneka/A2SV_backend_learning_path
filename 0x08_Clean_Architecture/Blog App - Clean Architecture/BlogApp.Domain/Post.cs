namespace BlogApp.Domain;

public class Post : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Comment>? Comments { get; set; }
}