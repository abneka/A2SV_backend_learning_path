using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.enums;

namespace A2SVLearningPath_Day4_Task1.Class
{
    public abstract class FileHandler
    {
        private const string Path = "../File/data.csv";
        
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

        public static List<TaskClass> LoadTasks()
        {
            List<TaskClass> tasks = new List<TaskClass>();
            try
            {
                string[] lines = File.ReadAllLines(Path);
                Console.WriteLine(lines.Length);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    tasks.Add( new TaskClass
                    {
                        Name = fields[0],
                        Description = fields[1],
                        Category = (TaskCategories)int.Parse(fields[2]),
                        IsCompleted = (fields[3] == "True")
                    });
                }

                return tasks;
            }
            catch (Exception exp)
            {
                Console.WriteLine("an error occurred while retrieving the file");
                return tasks;
                throw new ApplicationException("An Error Occured While retrieving Task: ", exp);
            }
        }
        
        public static List<TaskClass> LoadTasks(string category)
        {
            List<TaskClass> tasks = new List<TaskClass>();
            try
            {
                string[] lines = File.ReadAllLines(Path);
                lines = lines.Where(l => l.Split(',')[2] == category).ToArray();
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    tasks.Add( new TaskClass
                    {
                        Name = fields[0],
                        Description = fields[1],
                        Category = (TaskCategories)int.Parse(fields[2]),
                        IsCompleted = (fields[3] == "True")
                    });
                }

                return tasks;
            }
            catch (Exception exp)
            {
                Console.WriteLine("an error occurred while retrieving the file");
                return tasks;
                throw new ApplicationException("An Error Occured While retrieving Task: ", exp);
            }
        }
    }
}