using System;
using System.Linq;

namespace A2SVLearningPath
{
    public class Task01
    {
        public static void GetAverage()
        {
            Console.WriteLine("Please Enter Your name: ");
            string name = Console.ReadLine();
            int numberOfGrades;
            Console.WriteLine("please Enter Number of Subjects: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfGrades))
            {
                Console.WriteLine("Please Enter an Integer: ");
            }

            if (numberOfGrades < 1)
            {
                return;
            }

            string[] sub = new string[numberOfGrades];
            int[] grade = new int[numberOfGrades];
            for (var i = 1; i <= numberOfGrades; i++)
            {
                Console.WriteLine($"Please Enter Subject {i}'s Name: ");
                sub[i - 1] = Console.ReadLine();
                Console.WriteLine($"Please Enter {sub[i - 1]}'s Grade: ");
                while (!int.TryParse(Console.ReadLine(), out grade[i - 1]))
                {
                    Console.WriteLine("Please Enter an Integer: ");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Name: " + name);
            Console.ResetColor();

            string subjects = "subjects: " + string.Join(", ", sub);
            string grades = "Grades: " + grade[0].ToString();
            int total = grade[0];
            Console.WriteLine(subjects);
            for (var i = 1; i < numberOfGrades; i++)
            {
                total = total + grade[i];
                grades = grades + ", " + grade[i].ToString();
            }
            Console.WriteLine(grades);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Average: " + (total / numberOfGrades).ToString());
        }
    }
}