using A2SVLearningPath_Day7_task.Controllers;
using A2SVLearningPath_Day7_task.Data;
using A2SVLearningPath_Day7_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;

// This class contains unit tests for testing the functionality of controllers in the application.
// It uses the Xunit testing framework to define individual test methods for different controller actions.
// The tests are written to ensure that the controllers behave as expected and return the correct results.
// The tests are written to test the following:
namespace TestUnit;

public class UnitTest
{
    private ApiDbContext _context;
    
    public UnitTest()
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new ApiDbContext(options);
    }
    
    // 1. The Get() method in the PostManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task GetPosts()
    {
        //Arrange
        var controller = new PostManager(_context);
        
        //Act
        var result = await controller.Get();

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 2. The Get(id) method in the PostManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task GetPostById()
    {
        //Arrange
        var controller = new PostManager(_context);
        var id = 8;
        _context.Posts.Add(new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        });
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Get(id);

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }

    // 3. The Post(post) method in the PostManager controller returns a CreatedAtActionResult when called.
    [Fact]
    public async Task NewPost()
    {
        //Arrange
        var controller = new PostManager(_context);
        var post = new Post
        {
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        //Act
        var result = await controller.Post(post);
        
        //Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    // 4. The Put(id, title) method in the PostManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task UpdatePost()
    {
        //Arrange
        var controller = new PostManager(_context);
        var id = 7;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Put(id, "New Title");
        
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 5. The Delete(id) method in the PostManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task DeletePost()
    {
        //Arrange
        var controller = new PostManager(_context);
        var id = 6;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Delete(id);
        
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 6. The Get() method in the CommentManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task GetComments()
    {
        //Arrange
        var controller = new CommentManager(_context);
        var id = 5;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Get(id);

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 7. The Get(id) method in the CommentManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task GetCommentById()
    {
        //Arrange
        var controller = new CommentManager(_context);
        var id = 4;
        var comment = new Comment
        {
            CommentId = id,
            PostId = 1,
            Text = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Get(id);

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 8. The Post(comment) method in the CommentManager controller returns a CreatedAtActionResult when called.
    [Fact]
    public async Task NewComment()
    {
        //Arrange
        var controller = new CommentManager(_context);
        
        //the post must exist before adding a comment
        var id = 3;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        var comment = new Comment
        {
            PostId = 1,
            Text = "Test Body",
            CreatedAt = DateTime.Now
        };
        //Act
        var result = await controller.Post(comment);
        
        //Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
    
    // 9. The Put(id, content) method in the CommentManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task UpdateComment()
    {
        //Arrange
        var controller = new CommentManager(_context);
        
        //the post must exist before adding a comment
        var id = 2;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        var comment = new Comment
        {
            CommentId = id,
            PostId = 1,
            Text = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Put(id, "New Body");
        
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    // 10. The Delete(id) method in the CommentManager controller returns an OkObjectResult when called.
    [Fact]
    public async Task DeleteComment()
    {
        //Arrange
        var controller = new CommentManager(_context);
        
        //the post must exist before adding a comment
        var id = 1;
        var post = new Post
        {
            PostId = id,
            Title = "Test Title",
            Content = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        var comment = new Comment
        {
            CommentId = id,
            PostId = 1,
            Text = "Test Body",
            CreatedAt = DateTime.Now
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        
        //Act
        var result = await controller.Delete(id);
        
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
}