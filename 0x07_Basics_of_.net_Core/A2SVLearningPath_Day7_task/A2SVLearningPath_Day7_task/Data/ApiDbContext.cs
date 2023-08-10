using A2SVLearningPath_Day7_task.Models;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_task.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }

    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     modelBuilder.Entity<Post>(entity =>
    //     {
    //         entity.HasMany(post => post.Comments)
    //             .WithOne(com => com.Post)
    //             .HasForeignKey(com => com.PostId)
    //             .OnDelete(DeleteBehavior.Cascade)
    //             .HasConstraintName("ForeignKey_Comment_Post");
    //     });
    // }
}