namespace BlogApp.Domain;

public abstract class BaseEntity
{
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
}