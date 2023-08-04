using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.enums;

namespace A2SVLearningPath_Day4_Task1.Class
{
    
// This code defines a class called FileHandler that provides methods for adding, loading, and updating tasks in a CSV file.
    public abstract class FileHandler
    {
        // The class has a private constant string variable called "Path" that represents the file path of the CSV file.
        // The file path is set to "../File/data.csv".
        private const string Path = "../File/data.csv";
        
        // 1. AddData(TaskClass task): This method takes a TaskClass object as a parameter and asynchronously adds the task's data to the CSV file.
        // It uses a StreamWriter to write the task's properties (Name, Description, Category, IsCompleted) to a new line in the file.
        public static async Task AddData(TaskClass task)
        {

            try
            {
                using (StreamWriter file = new StreamWriter(Path, true))
                {
                    await file.WriteLineAsync(task.Name + "," + task.Description + "," +
                                   Array.IndexOf(Enum.GetValues(typeof(TaskCategories)), task.Category) + "," +
                                   task.IsCompleted);
                }

            }
            catch (Exception exp)
            {
                throw new ApplicationException("An Error Occured While Adding Task: ", exp);
            }
        }

        // 2. LoadTasks(): This method asynchronously loads all tasks from the CSV file and returns them as a List<TaskClass>.
        // It reads each line from the file using a StreamReader, splits the line into task details
        // using a comma as the delimiter, and creates a new TaskClass object with the extracted details.
        // The method then adds the task to the tasks list.
        public static async Task<List<TaskClass>> LoadTasks()
        {
            List<TaskClass> tasks = new List<TaskClass>();

            try
            {
                if (!File.Exists(Path))
                {
                    return tasks;
                }

                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] taskDetails = line.Split(',');

                        TaskClass taskItem = new TaskClass {
                            Name = taskDetails[0],
                            Description = taskDetails[1],
                            Category = (TaskCategories)int.Parse(taskDetails[2]),
                            IsCompleted = bool.Parse(taskDetails[3])
                        };

                        tasks.Add(taskItem);

                    }

                }
            }
                
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks from the file: {ex.Message}");
            }

            return tasks;
        }
        
        // 3. LoadTasks(string category): This method asynchronously loads tasks from the CSV file that match the specified category.
        // It calls the LoadTasks() method to get all tasks and then uses LINQ to filter the tasks based on the specified category.
        // The method returns the filtered tasks as an IEnumerable<TaskClass>.
        public static async Task<IEnumerable<TaskClass>> LoadTasks(string category)
        {
            List<TaskClass> tasks = await LoadTasks();
            return tasks.Where(line => line.Category == (TaskCategories)int.Parse(category));

        }
        
        // 4. LoadTasks(bool completion): This method asynchronously loads tasks from the CSV file that match the specified completion status.
        // It calls the LoadTasks() method to get all tasks and then uses LINQ to filter the tasks based on the specified completion status.
        // The method returns the filtered tasks as an IEnumerable<TaskClass>.
        public static async Task<IEnumerable<TaskClass>> LoadTasks(bool completion)
        {
            List<TaskClass> tasks = await LoadTasks();
            return tasks.Where(line => line.IsCompleted == completion);

        }
        
        // 5. UpdateName(int line, string data): This method asynchronously updates the name of a task at the specified line in the CSV file.
        // It calls the LoadTasks() method to get all tasks, checks if the specified line is within the range of the
        // tasks list, updates the name of the task at the specified line, and then calls the Rewrite() method to rewrite all tasks to the CSV file.
        // The method returns a boolean indicating whether the update was successful.
        public static async Task<bool> UpdateName(int line, string data)
        {
            List<TaskClass> tasks = await LoadTasks();
            if (tasks.Count < line)
            {
                return false;
            }

            tasks[line - 1].Name = data;

            await Rewrite(tasks);

            return true;
        }
        
        // 6. UpdateDescription(int line, string data): This method asynchronously updates the description of
        // a task at the specified line in the CSV file.
        // It follows a similar logic to the UpdateName() method but updates the description instead.
        public static async Task<bool> UpdateDescription(int line, string data)
        {
            List<TaskClass> tasks = await LoadTasks();
            if (tasks.Count < line)
            {
                return false;
            }

            tasks[line - 1].Description = data;

            await Rewrite(tasks);

            return true;
        }
        
        // 7. ToggleCompletion(int line): This method asynchronously toggles the completion status of a
        // task at the specified line in the CSV file.
        // It follows a similar logic to the UpdateName() method but toggles the completion status instead.
        public static async Task<bool> ToggleCompletion(int line)
        {
            List<TaskClass> tasks = await LoadTasks();
            if (tasks.Count < line)
            {
                return false;
            }

            tasks[line - 1].IsCompleted = !tasks[line - 1].IsCompleted;

            await Rewrite(tasks);

            return true;
        }

        // 8. Rewrite(List<TaskClass> tasks): This method asynchronously rewrites all tasks in the CSV file.
        // It uses a StreamWriter to write each task's properties (Name, Description, Category, IsCompleted)
        // to a new line in the file, overwriting the existing content.
        private static async Task Rewrite(List<TaskClass> tasks)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(Path, false))
                {
                    foreach (var task in tasks)
                    {
                        await file.WriteLineAsync(task.Name + "," + task.Description + "," +
                                                  Array.IndexOf(Enum.GetValues(typeof(TaskCategories)), task.Category) + "," +
                                                  task.IsCompleted);
                    }
                }

            }
            catch (Exception exp)
            {
                throw new ApplicationException("An Error Occured While Adding Task: ", exp);
            }
        }
    }
}