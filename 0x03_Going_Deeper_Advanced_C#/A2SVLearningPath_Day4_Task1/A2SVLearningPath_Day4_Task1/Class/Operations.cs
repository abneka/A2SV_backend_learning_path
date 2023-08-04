using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.enums;

namespace A2SVLearningPath_Day4_Task1.Class
{
    public abstract class Operations
    {
        // This method allows the user to add a new task.
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
            await FileHandler.AddData(firstTask);
        }

        // This private method displays all the tasks in a formatted manner and returns the total number of tasks.
    private static int Display(IEnumerable<TaskClass> tasks)
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

        return index - 1;
    }

    // This method displays all the tasks by calling the Display method with the loaded tasks from the FileHandler class.
    public static async Task<int> GetAllTask()
    {
        return Display(await FileHandler.LoadTasks());
    }

    // This method filters the tasks based on the selected category and displays them.
    public static async Task Filter()
    {
        int prompt;
        Console.WriteLine("press the corresponding number to Filter BY");
        Console.WriteLine("1. Personal");
        Console.WriteLine("2. Work");
        Console.WriteLine("3. Errands");
        Console.Write(" ==> ");
        while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
        {
            Console.WriteLine("Please Enter numbers between 1 and 3");
            Console.Write(" ==> ");
        }

        Display(await FileHandler.LoadTasks((prompt - 1).ToString()));
    }

    // This method filters the tasks based on the completion status and displays them.
    public static async Task FilterByCompletion()
    {
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
        
        Display(await FileHandler.LoadTasks(comp == 1));
    }

    // This method allows the user to update a task's name, description, or completion status.
    public static async Task Update()
    {
        int prompt;
        Console.WriteLine("press the corresponding number to Update");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Description");
        Console.WriteLine("3. Toggle Completion");
        Console.Write(" ==> ");
        while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
        {
            Console.WriteLine("Please Enter numbers between 1 and 3");
            Console.Write(" ==> ");
        }
        
        Console.WriteLine("press the corresponding Task number to Update");
        int count = await GetAllTask();
        int line;
        Console.Write(" Task Number ==> ");
        if (!int.TryParse(Console.ReadLine(), out line) || line < 1 || line > count)
        {
            Console.WriteLine($"Please Enter numbers between 1 and {count}");
            Console.Write(" ==> ");
        }

        string data = " ";

        if (prompt != 3)
        {
            Console.WriteLine("New Data: ");
            data = Console.ReadLine();
        }

        // Based on the selected prompt, call the appropriate method from the FileHandler class to update the task.
        switch (prompt)
        {
            case 1:
                await FileHandler.UpdateName(line, data);
                break;
            case 2:
                await FileHandler.UpdateDescription(line, data);
                break;
            case 3:
                await FileHandler.ToggleCompletion(line);
                break;
        }
    }
}}