using A2SVLearningPath_Day7_task.Data;
using A2SVLearningPath_Day7_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostManager : ControllerBase
{
    private static ApiDbContext _context;

    public PostManager(ApiDbContext context)
    {
        _context = context;
    }
    
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
    
    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", post.PostId, post);
    }
    
    [HttpPut]
    // [Route("/title")]
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
    
}
