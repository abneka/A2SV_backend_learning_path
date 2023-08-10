using A2SVLearningPath_Day7_Console.Class;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_Console.Data;

//this class is responsible for managing the database
public class ApiDbContext : DbContext
{
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=learningpath;Username=postgres;Password=admin");
    }
}