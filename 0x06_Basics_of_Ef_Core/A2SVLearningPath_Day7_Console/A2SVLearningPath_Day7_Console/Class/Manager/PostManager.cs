using A2SVLearningPath_Day7_Console.Data;
using Microsoft.EntityFrameworkCore;

namespace A2SVLearningPath_Day7_Console.Class.Manager;


// This code represents a PostManager class responsible for managing posts in the application. 
// It interacts with an instance of the ApiDbContext class to perform CRUD operations on posts.
// The code handles error scenarios by displaying error messages in red text and provides a structured way to interact with the post management functionality.
// Overall, this code demonstrates a professional approach to managing posts in the application, ensuring data integrity, and providing informative feedback to the user.
public class PostManager
{
    private static ApiDbContext _dbContext = new ApiDbContext();
    
    // The CreatePost method adds a new post to the database after validating that the title and content are not empty or whitespace. 
    // It throws an exception if either is missing.
    public static void CreatePost(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Title))
        {
            throw new Exception("Post title is required");
        }
        if (string.IsNullOrWhiteSpace(post.Content))
        {
            throw new Exception("Post content is required");
        }
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
    }
    
    // The UpdatePost method updates an existing post in the database by finding it based on the post ID. 
    // It validates the title and content and displays an error message if either is missing. 
    // If the post is found, it updates the title, content, and saves the changes.
public static void UpdatePost(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Title))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post title is required");
        }
        if (string.IsNullOrWhiteSpace(post.Content))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post content is required");
        }

        var postToUpdate = _dbContext.Posts.FirstOrDefault(p => p.PostId == post.PostId);
        if (postToUpdate == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post not found");
        }
        else
        {
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            _dbContext.SaveChanges();
        }
        
    }

    // The DeletePost method deletes a post from the database by finding it based on the post ID. 
    // If the post is not found, it displays an error message. If the post is found, it removes it from the database and saves the changes.
public static void DeletePost(int postId)
    {
        var postToDelete = _dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
        if (postToDelete == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post not found");
        }
        else
        {
            _dbContext.Posts.Remove(postToDelete);
            _dbContext.SaveChanges();
        }
    }


    // The GetPost method retrieves a post from the database based on the post ID. 
    // It includes the associated comments for the post. If the post is not found, it displays an error message. 
    // If the post is found, it displays the post's ID, title, content, creation timestamp, and the associated comments.
public static void GetPost(int postId)
    {
        var post = _dbContext.Posts.Include(p => p.Comments)
            .FirstOrDefault(p => p.PostId == postId);
        if (post == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post not found");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"PostId: {post.PostId}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Content: {post.Content}");
            Console.WriteLine($"CreatedAt: {post.CreatedAt}");
            Console.WriteLine($"Comments: {post.Comments.Count}");
            Console.WriteLine("--------------------------------------------------");
            foreach (var comment in post.Comments)
            {
                Console.WriteLine($"CommentId: {comment.CommentId}");
                Console.WriteLine($"Comment Text: {comment.Text}");
                Console.WriteLine($"Comment Created At: {comment.CreatedAt}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }

    // The GetPosts method retrieves all posts from the database. It includes the associated comments for each post. 
    // If no posts are found, it displays an error message. 
    // If posts are found, it displays each post's ID, title, content, creation timestamp, and the associated comments.
public static void GetPosts()
    {
        var posts = _dbContext.Posts.Include(p => p.Comments).ToList();
        if (posts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No posts found");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var post in posts)
            {
                Console.WriteLine($"PostId: {post.PostId}");
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Content: {post.Content}");
                Console.WriteLine($"CreatedAt: {post.CreatedAt}");
                Console.WriteLine($"Comments: {post.Comments.Count}");
                Console.WriteLine("--------------------------------------------------");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"CommentId: {comment.CommentId}");
                    Console.WriteLine($"Comment Text: {comment.Text}");
                    Console.WriteLine($"Comment Created At: {comment.CreatedAt}");
                    Console.WriteLine("--------------------------------------------------");
                }
            }
        }
    }
}