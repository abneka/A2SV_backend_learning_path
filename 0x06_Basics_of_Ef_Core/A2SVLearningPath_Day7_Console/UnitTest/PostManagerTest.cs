using A2SVLearningPath_Day7_Console.Class;
using A2SVLearningPath_Day7_Console.Class.Manager;
using A2SVLearningPath_Day7_Console.Class.Menu;
using A2SVLearningPath_Day7_Console.Data;
using Xunit;

namespace UnitTest;

public class PostManagerTest
{
    [Fact]
    public void CreatePost_WhenCalled_ReturnsPost()
    {
        using var context = new ApiDbContext();
        PostManager.CreatePost(new Post
        {
            Title = "title",
            Content = "content",
            Comments = new List<Comment>(),
            PostId = 1
        });

        Assert.Single(context.Posts);
        Assert.Equal("title", context.Posts.First().Title);
        Assert.Equal("content", context.Posts.First().Content);
    }
    
    [Fact]
    public void EditPost()
    {
        using var context = new ApiDbContext();
        
        PostManager.CreatePost(new Post
        {
            Title = "oldTitle",
            Content = "oldContent",
            Comments = new List<Comment>(),
            PostId = 1
        });
        Assert.Single(context.Posts);
        Assert.Equal("oldTitle", context.Posts.First().Title);
        Assert.Equal("oldContent", context.Posts.First().Content);
        
        PostManager.UpdatePost(new Post
        {
            Title = "newTitle",
            Content = "newContent",
            PostId = 1
        });
        
        Assert.Single(context.Posts);
        Assert.Equal("newTitle", context.Posts.First().Title);
        Assert.Equal("newContent", context.Posts.First().Content);
    }
    
    [Fact]
    public void DeletePost()
    {
        using var context = new ApiDbContext();
        
        PostManager.CreatePost(new Post
        {
            Title = "title",
            Content = "content",
            Comments = new List<Comment>(),
            PostId = 3
        });
        
        PostManager.DeletePost(1);
        
        Assert.Empty(context.Posts);
    }
}