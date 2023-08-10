using A2SVLearningPath_Day7_Console.Class.Manager;

namespace A2SVLearningPath_Day7_Console.Class.Menu;

//This code represents a menu system for managing posts and comments.
//It provides a user-friendly interface for interacting with the PostManager and CommentManager classes.
public class Menu
{
    
    //The ShowMenu method displays the main menu options and handles the user's choice until they choose to exit.
    // Overall, this code provides a structured and intuitive way for users to interact
    // with the post and comment management functionality.
    public static void ShowMenu()
    {
        var choice = "";
        while (choice != "3")
        {
            choice = MainMenu();
            switch (choice)
            {
                case "1":
                    PostMenu();
                    break;
                case "2":
                    CommentMenu();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    // The MainMenu method displays the main menu options and returns the user's choice as a string.
    // Within these methods, the user's choice is processed using a switch statement to call
    // the appropriate methods from the PostManager and CommentManager classes.
    // The user is prompted to enter their choice, and the program loops until a
    // valid choice is made or the user chooses to return to the main menu.
    // Invalid choices are handled by displaying an error message in red text.
    private static string MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Posts");
        Console.WriteLine("2. Comments");
        Console.WriteLine("3. Exit");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter your choice: ");
        return Console.ReadLine();
    }

    // The PostMenu and CommentMenu methods display the sub-menu options for managing posts and comments, respectively.
    private static void PostMenu()
    {
        var choice = "";
        while (choice != "6")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. Update Post");
            Console.WriteLine("3. Delete Post");
            Console.WriteLine("4. Get Post");
            Console.WriteLine("5. Get All Posts");
            Console.WriteLine("6. Main Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your choice: ");
            choice =  Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PostManager.CreatePost(UserInput.PostInfo());
                    break;
                case "2":
                    PostManager.UpdatePost(UserInput.PostToUpdate());
                    break;
                case "3":
                    PostManager.DeletePost(UserInput.GetPostId());
                    break;
                case "4":
                    PostManager.GetPost(UserInput.GetPostId());
                    break;
                case "5":
                    PostManager.GetPosts();
                    break;
                case "6":
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private static void CommentMenu()
    {
        var choice = "";
        while (choice != "6")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Create Comment");
            Console.WriteLine("2. Update Comment");
            Console.WriteLine("3. Delete Comment");
            Console.WriteLine("4. Get Comment");
            Console.WriteLine("5. Get All Comments");
            Console.WriteLine("6. Main Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your choice: ");
            choice =  Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CommentManager.CreateComment(UserInput.CommentInfo());
                    break;
                case "2":
                    CommentManager.UpdateComment(UserInput.CommentToUpdate());
                    break;
                case "3":
                    CommentManager.DeleteComment(UserInput.GetCommentId());
                    break;
                case "4":
                    CommentManager.GetComment(UserInput.GetCommentId());
                    break;
                case "5":
                    CommentManager.GetComments();
                    break;
                case "6":
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}