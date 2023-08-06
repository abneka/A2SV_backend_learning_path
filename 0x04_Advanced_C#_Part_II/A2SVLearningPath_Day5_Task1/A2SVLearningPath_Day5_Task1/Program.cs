using System;
using System.Collections.Generic;
using A2SVLearningPath_Day5_Task1.Class;

namespace A2SVLearningPath_Day5_Task1
{
    internal class Program
    {
        // Overall, this code provides a simple and interactive way to manage a list of students through a console interface.
        // It demonstrates the use of classes, methods, and control flow structures to achieve the desired functionality.
        public static void Main(string[] args)
        {
            // This code represents a console application that manages a list of students.
            // It provides a menu-driven interface for performing various operations such as adding students,
            // searching for students by name or ID, displaying all students, sorting students by name or age,
            // updating student information, Removing students from Json(and List),  and exiting the program.
            Menu();
        }

        // The "Menu" method uses a while loop to continuously display the menu until the user chooses to exit.
        private static void Menu()
        {
            var loop = true;
            while (loop)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student by Name");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Sort By Name");
                Console.WriteLine("6. Sort By Age");
                Console.WriteLine("7. Update Student Info");
                Console.WriteLine("8. Remove Student");
                Console.WriteLine("9. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                // Based on the user's choice, the code uses a switch statement to execute the corresponding
                // functionality.
                switch (choice)
                {
                    case "1":
                        UserInput.NewStudent();
                        break;

                    case "2":
                        UserInput.GetByName();
                        break;

                    case "3":
                        UserInput.GetByRoll();
                        break;

                    case "4":
                        StudentList<Student>.DisplayAll();
                        break;
                    
                    case "5":
                        StudentList<Student>.SortByName();
                        break;
                    
                    case "6":
                        StudentList<Student>.SortByAge();
                        break;
                    
                    case "7":
                        UserInput.Update();
                        break;

                    case "8":
                        UserInput.RemoveStudent();
                        break;
                    
                    case "9":
                        loop = false;
                        break;

                    // If the user enters an invalid choice, the code displays an error message and prompts the user
                    // to try again.
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}