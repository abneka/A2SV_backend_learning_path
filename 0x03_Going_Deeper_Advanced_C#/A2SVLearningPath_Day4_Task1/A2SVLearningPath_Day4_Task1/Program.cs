using System;
using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.Class;

namespace A2SVLearningPath_Day4_Task1
{
    internal abstract class Program
    {
        public static async Task Main(string[] args)
        {
            await Menu();// Entry point of the application, calls the Menu method to display the main menu.
        }

           private static async Task Menu()
    {
        int prompt = 1;
        while (prompt > 0 && prompt < 4) // The loop continues until the user enters a number outside the range of 1 to 3.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     => Task Manager <=");
            Console.WriteLine("press the corresponding number to activate the actions");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update Tasks");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any number to exit");
            Console.Write(" ==> ");
            if (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 2 (or any number to exit)");
                Console.Write(" ==> ");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (prompt)
            {
                case 1:
                    await Operations.AddTask(); // Calls the AddTask method from the Operations class to add a new task.
                    break;

                case 2:
                    await ViewMenu(); // Calls the ViewMenu method to display the view menu options.
                    break;
                
                case 3:
                    await Operations.Update(); // Calls the Update method from the Operations class to update tasks.
                    break;

                default:
                    Console.WriteLine("Returning to Menu");
                    break;
            }
        }
    }

    private static async Task ViewMenu()
    {
        int prompt = 1;
        while (prompt > 0 && prompt < 4) // The loop continues until the user enters a number outside the range of 1 to 3.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     => View Task <=");
            Console.WriteLine("press the corresponding number to activate the actions");
            Console.WriteLine("1. View All Tasks");
            Console.WriteLine("2. Filter By Category");
            Console.WriteLine("3. Filter By Completion");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any number to goto previous menu");
            Console.Write(" ==> ");
            if (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 3 (or any number to return)");
                Console.Write(" ==> ");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (prompt)
            {
                case 1:
                    await Operations.GetAllTask(); // Calls the GetAllTask method from the Operations class to view all tasks.
                    break;

                case 2:
                    await Operations.Filter(); // Calls the Filter method from the Operations class to filter tasks by category.
                    break;
                
                case 3:
                    await Operations.FilterByCompletion(); // Calls the FilterByCompletion method from the Operations class to filter tasks by completion status.
                    break;

                default:
                    Console.WriteLine("Returning to Menu");
                    break;
            }
        }
    }
}}