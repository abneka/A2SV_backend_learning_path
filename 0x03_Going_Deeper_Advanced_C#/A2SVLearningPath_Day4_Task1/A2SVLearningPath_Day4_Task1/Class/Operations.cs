using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.enums;

namespace A2SVLearningPath_Day4_Task1.Class
{
    public abstract class Operations
    {
        public static async Task AddTask()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please Input Task's Name");
            string name = Console.ReadLine();
            Console.WriteLine($"Please Input {name}'s Description");
            string desc = Console.ReadLine();
            int prompt;
            Console.WriteLine("press the corresponding number to Choose Category");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Personal");
            Console.WriteLine("3. Errands");
            Console.Write(" ==> ");
            while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 3");
                Console.Write(" ==> ");
            }

            int comp;
            Console.WriteLine("press the corresponding number to Choose Category");
            Console.WriteLine("1. Completed");
            Console.WriteLine("2. Not Completed");
            Console.Write(" ==> ");
            while (!int.TryParse(Console.ReadLine(), out comp) || comp < 1 || comp > 2)
            {
                Console.WriteLine("Please Enter numbers between 1 and 2");
                Console.Write(" ==> ");
            }

            TaskClass firstTask = new TaskClass
            {
                Name = name,
                Description = desc,
                Category = (TaskCategories)(prompt - 1),
                IsCompleted = (1 == comp)
            };
            // Task firstTask = new Task { 
            //     Name = "Going Deeper In Advanced C#", 
            //     Description = "This is the task for Day 4 advanced C#", 
            //     Category = TaskCategories.Work,
            //     IsCompleted = false
            // };
            await FileHandler.AddData(firstTask);
        }

        private static void Display(List<TaskClass> tasks)
        {
            int index = 1;
            foreach (var task in tasks)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    XXXXXXXXXXXXXXXX Task {index} XXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Task Name: " + task.Name);
                Console.WriteLine("Task Description: " + task.Description);
                Console.WriteLine("Task Category: " + task.Category);
                Console.WriteLine("Is Completed: " + task.IsCompleted);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                index = index + 1;
            }
        }

        public static void GetAllTask()
        {
            Display(FileHandler.LoadTasks());
        }

        public static void Filter()
        {
            int prompt;
            Console.WriteLine("press the corresponding number to Filter BY");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Personal");
            Console.WriteLine("3. Errands");
            Console.Write(" ==> ");
            while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 3");
                Console.Write(" ==> ");
            }

            Display(FileHandler.LoadTasks((prompt - 1).ToString()));
        }
    }
}