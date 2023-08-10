using A2SVLearningPath_Day7_task.Data;
using A2SVLearningPath_Day7_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentManager : ControllerBase
{
    private ApiDbContext _context;

    public CommentManager(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet("{PostId:int}")]
    public async Task<IActionResult> Get(int PostId)
    {
        var comments = await _context.Comments.Where(c => c.PostId == PostId).ToListAsync();
        return Ok(comments);
    }

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