namespace A2SVLearningPath_Day7_task.Models;

public class Post
{
    // public Post()
    // {
    //     Comments = new HashSet<Comment>();
    // }
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Comment>? Comments { get; set; }
}
