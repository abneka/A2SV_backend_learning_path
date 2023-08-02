using System;
using System.Collections.Generic;

namespace A2SVLearningPath_Day3_task2
{
    public class UserInput
    {
        public static string[] NewBook()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please Input Book's Title");
            string title = Console.ReadLine();
            Console.WriteLine($"Please Input {title}'s Author");
            string author = Console.ReadLine();
            Console.WriteLine($"Please Input {title}'s ISBN");
            string isbn = Console.ReadLine();
            Console.WriteLine($"Please Input {title}'s Publication Year");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > DateTime.Now.Year)
            {
                Console.WriteLine("please Enter valid year");
            }

            string[] input = { title, author, isbn, $"{year}" };

            return input;
        }
        
        public static string[] NewMedia()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please Input Media's Title");
            string title = Console.ReadLine();
            Console.WriteLine($"Please Input {title}'s Type");
            string type = Console.ReadLine();
            Console.WriteLine($"Please Input {title}'s Duration");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration < 1 )
            {
                Console.WriteLine("please Enter valid duration");
            }

            string[] input = { title, type, $"{duration}" };

            return input;
        }
    }
}