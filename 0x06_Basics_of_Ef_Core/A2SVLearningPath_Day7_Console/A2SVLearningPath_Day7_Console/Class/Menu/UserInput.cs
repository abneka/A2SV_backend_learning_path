using A2SVLearningPath_Day7_Console.Class.Manager;

namespace A2SVLearningPath_Day7_Console.Class.Menu;

// This code provides utility methods for capturing user input related to posts and comments.
// It ensures that the input is valid and properly formatted before returning the corresponding objects or IDs.
// Overall, this code provides a convenient and error-handling mechanism for capturing user input related to 
// posts and comments in a structured and reliable manner.
public class UserInput
{
    // The PostInfo method prompts the user to enter the title and content of a post, creates a new Post object, 
    // sets the properties, initializes an empty list of comments, and returns the post.    
    public static Post PostInfo()
    {
        var post = new Post();
        Console.Write("Enter title: ");
        post.Title = Console.ReadLine();
        Console.Write("Enter content: ");
        post.Content = Console.ReadLine();
        post.Comments = new List<Comment>();
        return post;
    }
    
    // The CommentInfo method prompts the user to enter the text of a comment, creates a new Comment object, 
    // sets the text property, and assigns the PostId by calling the GetPostId method.
    public static Comment CommentInfo()
    {
        var comment = new Comment();
        Console.Write("Enter text: ");
        comment.Text = Console.ReadLine();
        comment.PostId = GetPostId();
        return comment;
    }
    // The CommentToUpdate method is similar to CommentInfo but also assigns the CommentId by calling the GetCommentId method.
    public static Comment CommentToUpdate()
    {
        var comment = new Comment();
        Console.Write("Enter text: ");
        comment.Text = Console.ReadLine();
        comment.CommentId = GetCommentId();
        return comment;
    }
    
    // The PostToUpdate method prompts the user to enter the title, content, and ID of a post, creates a new Post object, 
    // sets the properties, validates the ID input, and returns the post.
    public static Post PostToUpdate()
    {
        var post = new Post();
        Console.Write("Enter title: ");
        post.Title = Console.ReadLine();
        Console.Write("Enter content: ");
        post.Content = Console.ReadLine();
        Console.Write("Enter post id: ");
        int postId;
        while (!int .TryParse(Console.ReadLine(), out postId))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post id must be a number");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter post id: ");
        }
        post.PostId = postId;
        return post;
    }
    
    // The GetPostId and GetCommentId methods display the available posts or comments, prompt the user to enter 
    // the corresponding ID, validate the input, and return the ID as an integer.
    // Invalid ID inputs are handled by displaying an error message in red text and prompting the user to enter a valid ID.
    public static int GetPostId()
    {
        PostManager.GetPosts();
        Console.Write("Enter post id: ");
        int postId;
        while (!int .TryParse(Console.ReadLine(), out postId))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Post id must be a number");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter post id: ");
        }
        return postId;
    }

public static int GetCommentId()
    {
        CommentManager.GetComments();
        Console.Write("Enter comment id: ");
        int commentId;
        while (!int .TryParse(Console.ReadLine(), out commentId))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Comment id must be a number");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter comment id: ");
        }
        return commentId;
    }
}
