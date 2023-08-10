using A2SVLearningPath_Day7_task.Data;
using A2SVLearningPath_Day7_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_task.Controllers;

// This code defines a controller class called CommentManager that handles API requests related to comments on posts.
// It is part of a larger project that includes a data context class (ApiDbContext) and a model class (Comment).
// Overall, this code provides a basic implementation of a comment management API, allowing users to
// retrieve, create, update, and delete comments associated with posts.
// It utilizes the Entity Framework Core for database operations and follows the RESTful API conventions.

// The CommentManager class is decorated with the [Route] and [ApiController] attributes, which indicate that
// this class handles API requests and specifies the route prefix for the controller's endpoints.
[Route("api/[controller]")]
[ApiController]
public class CommentManager : ControllerBase
{
    private ApiDbContext _context;

    // The class has a constructor that takes an instance of ApiDbContext as a parameter. This allows the controller
    // to access the database context for performing CRUD operations on the Comment entities.
    public CommentManager(ApiDbContext context)
    {
        _context = context;
    }

    // 1. The Get method is an HTTP GET request that retrieves all comments associated with a specific post.
    // It takes a PostId as a parameter and uses the _context to query the database for comments with the matching PostId.
    // The comments are then returned as an IActionResult.
    [HttpGet("{PostId:int}")]
    public async Task<IActionResult> Get(int PostId)
    {
        var comments = await _context.Comments.Where(c => c.PostId == PostId).ToListAsync();
        return Ok(comments);
    }

    // 2. The Post method is an HTTP POST request that adds a new comment to a post. It takes a Comment object as a parameter,
    // which represents the comment to be added. The method first checks if the associated post exists in the database.
    // If not, it returns a BadRequest response. Otherwise, it adds the comment to the _context, saves the changes to
    // the database, and returns a CreatedAtAction response with the newly created comment.
    [HttpPost]
    public async Task<IActionResult> Post(Comment comment)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == comment.PostId);
        
        if (post == null)
        {
            return BadRequest("Post not found");
        }
        
        Console.WriteLine(comment.Text);
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", new { comment.PostId }, comment);

    }
    
    // 3. The Put method is an HTTP PUT request that updates the content of an existing comment.
    // It takes an id and content as parameters, representing the comment's unique identifier and the new content.
    // The method retrieves the existing comment from the _context based on the id, updates its content, saves the changes
    // to the database, and returns the updated comment.
    [HttpPut]
    public async Task<IActionResult> Put(int id, string content)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        
        if (existingComment == null)
        {
            return BadRequest("Comment not found");
        }
        
        existingComment.Text = content;
        await _context.SaveChangesAsync();
        return Ok(existingComment);
    }
    
    
    // 4. The Delete method is an HTTP DELETE request that deletes an existing comment. It takes an id as a parameter,
    // representing the comment's unique identifier.
    // The method retrieves the existing comment from the _context based on the id, removes it from the _context, saves
    // the changes to the database, and returns the deleted comment.
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        
        if (existingComment == null)
        {
            return BadRequest("Comment not found");
        }
        
        _context.Comments.Remove(existingComment);
        await _context.SaveChangesAsync();
        return Ok(existingComment);
    }
}