using A2SVLearningPath_Day7_Console.Data;

namespace A2SVLearningPath_Day7_Console.Class.Manager;

// This code represents a CommentManager class responsible for managing comments in the application. 
// It interacts with an instance of the ApiDbContext class to perform CRUD operations on comments.
// The code handles error scenarios by displaying error messages in red text and provides a structured way to interact with the comment management functionality.
// Overall, this code demonstrates a professional approach to managing comments in the application, ensuring data integrity and providing informative feedback to the user.
public class CommentManager
{
    private static ApiDbContext _dbContext = new ApiDbContext();
    
    // The CreateComment method adds a new comment to the database after validating that the comment text is not empty or whitespace. 
    // It throws an exception if the text is missing.
    public static void CreateComment(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Text))
        {
            throw new Exception("Comment text is required");
        }
        _dbContext.Comments.Add(comment);
        _dbContext.SaveChanges();
    }
    
    // The UpdateComment method updates an existing comment in the database by finding it based on the comment ID. 
    // It validates the comment text and displays an error message if it is missing. If the comment is found, it updates the text and saves the changes.
    public static void UpdateComment(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Text))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Comment text is required");
        }

        var commentToUpdate = _dbContext.Comments.FirstOrDefault(c => c.CommentId == comment.CommentId);
        if (commentToUpdate == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Comment not found");
        }
        else
        {
            commentToUpdate.Text = comment.Text;
            _dbContext.SaveChanges();
        }
        
    }
    
    // The DeleteComment method deletes a comment from the database by finding it based on the comment ID. 
    // If the comment is not found, it displays an error message. If the comment is found, it removes it from the database and saves the changes.
    public static void DeleteComment(int commentId)
    {
        var commentToDelete = _dbContext.Comments.FirstOrDefault(c => c.CommentId == commentId);
        if (commentToDelete == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Comment not found");
        }
        else
        {
            _dbContext.Comments.Remove(commentToDelete);
            _dbContext.SaveChanges();
        }
    }
    
    // The GetComment method retrieves a comment from the database based on the comment ID. 
    // If the comment is not found, it displays an error message. If the comment is found, it displays the comment's ID, text, and creation timestamp.
    public static void GetComment(int commentId)
    {
        var comment = _dbContext.Comments.FirstOrDefault(c => c.CommentId == commentId);
        if (comment == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Comment not found");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Comment Id: {comment.CommentId}");
            Console.WriteLine($"Comment Text: {comment.Text}");
            Console.WriteLine($"Comment Created At: {comment.CreatedAt}");
        }
    }
    
    // The GetComments method retrieves all comments from the database. If no comments are found, it displays an error message. 
    // If comments are found, it displays each comment's ID, text, and creation timestamp.
    public static void GetComments()
    {
        var comments = _dbContext.Comments.ToList();
        if (comments.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No comments found");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var comment in comments)
            {
                Console.WriteLine($"Comment Id: {comment.CommentId}");
                Console.WriteLine($"Comment Text: {comment.Text}");
                Console.WriteLine($"Comment Created At: {comment.CreatedAt}");
                Console.WriteLine("------------------------------------------------");
            }
        }
    }
}