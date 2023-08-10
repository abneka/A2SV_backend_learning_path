using A2SVLearningPath_Day7_task.Data;
using A2SVLearningPath_Day7_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_task.Controllers;

// This code defines a controller class called PostManager that handles API requests related to comments on posts.
// It is part of a larger project that includes a data context class (ApiDbContext) and a model class (Post).
// Overall, this code provides a basic implementation of a post management API, allowing users to
// retrieve, create, update, and delete posts associated with comments.
// It utilizes the Entity Framework Core for database operations and follows the RESTful API conventions.

// The PostManager class is decorated with the [Route] and [ApiController] attributes, which indicate that
// this class handles API requests and specifies the route prefix for the controller's endpoints.

[Route("api/[controller]")]
[ApiController]
public class PostManager : ControllerBase
{
    private static ApiDbContext _context;

    // The class has a constructor that takes an instance of ApiDbContext as a parameter. This allows the controller
    // to access the database context for performing CRUD operations on the Post entities.
    public PostManager(ApiDbContext context)
    {
        _context = context;
    }
    
    // 1. The Get method is an HTTP GET request that retrieves all posts.
    // The posts are then returned as an IActionResult.
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var posts = await _context.Posts.ToListAsync();
        foreach (var post in posts)
        {
            post.Comments = await _context.Comments.Where(comm => comm.PostId == post.PostId).ToListAsync();
        }
        return Ok(posts);
    }
    
    // 2. The Post method is an HTTP POST request that adds a new post. It takes a Post object as a parameter,
    // which represents the post to be added. It adds the post to the _context, saves the changes to
    // the database, and returns a CreatedAtAction response with the newly created post.
    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", post.PostId, post);
    }
    
    // 3. The Put method is an HTTP PUT request that updates the content of an existing post.
    // It takes an id and content as parameters, representing the post's unique identifier and the new content.
    // The method retrieves the existing post from the _context based on the id, updates its content, saves the changes
    // to the database, and returns the updated post.
    [HttpPut]
    public async Task<IActionResult> Put(int id, string title)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        
        if (existingPost == null)
        {
            return BadRequest("Post not found");
        }
        
        existingPost.Title = title;
        await _context.SaveChangesAsync();
        return Ok(existingPost);
    }
    
    // 4. The Delete method is an HTTP DELETE request that deletes an existing post. It takes an id as a parameter,
    // representing the post's unique identifier.
    // The method retrieves the existing post from the _context based on the id, removes it from the _context, saves
    // the changes to the database, and returns the deleted post.
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        
        if (existingPost == null)
        {
            return BadRequest("Post not found");
        }
        
        _context.Posts.Remove(existingPost);
        await _context.SaveChangesAsync();
        return Ok(existingPost);
    }
    
    // 5. The Get method is an HTTP GET request that retrieves specific post.It takes an id as a parameter,
    // representing the post's unique identifier.
    // The method retrieves the existing post from the _context based on the id, return bad request if not found.
    // The post is then returned as an IActionResult.
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        
        if (post == null)
        {
            return BadRequest("Post not found");
        }
        post.Comments = await _context.Comments.Where(comm => comm.PostId == post.PostId).ToListAsync();
        
        return Ok(post);
    }
    
}
