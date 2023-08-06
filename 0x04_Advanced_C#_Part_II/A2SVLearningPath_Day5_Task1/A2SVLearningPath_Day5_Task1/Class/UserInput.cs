using System;
using System.Collections.Generic;

namespace A2SVLearningPath_Day5_Task1.Class
{
    
    // This code defines a class called UserInput, which contains several static methods for interacting with student data. 
    public class UserInput
    {
        // The NewStudent method prompts the user to input a student's full name, age, roll number, and grade.
        // It validates the input and adds a new Student object to the StudentList.
        public static void NewStudent()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please Input Student's Full Name");
            string name = Console.ReadLine();
            Console.WriteLine($"Please Input {name}'s Age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 100)
            {
                Console.WriteLine("please Enter valid Age");
            }
            Console.WriteLine($"Please Input {name}'s RollNumber");
            int roll;
            while (!int.TryParse(Console.ReadLine(), out roll) || roll < 1)
            {
                Console.WriteLine("please Enter valid RollNumber");
            }
            Console.WriteLine($"Please Input {name}'s Grade");
            float grade;
            while (!float.TryParse(Console.ReadLine(), out grade) || grade < 1f || grade > 4f)
            {
                Console.WriteLine("please Enter valid year");
            }

            StudentList<Student>.AddStudent(new Student(name, age, roll, grade));
        }

        // The GetByName method prompts the user to enter a name to search for in the StudentList.
        // It retrieves all students with matching names and displays their information.
        public static void GetByName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Name to search: ");
            string searchName = Console.ReadLine();

            var values = StudentList<Student>.GetStudentByName(searchName);

            if (values == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Match Found");
            }
            else
            {
                foreach (var value in values)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(value.Name);
                    Console.WriteLine(value.Age);
                    Console.WriteLine(value.RollNumber);
                    Console.WriteLine(value.Grade);
                }
            }
        }

        // The GetByRoll method prompts the user to enter a roll number to search for in the StudentList.
        // It retrieves the student with the matching roll number and displays their information.
        public static void GetByRoll()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Roll Number to search: ");
            int roll;
            while (!int.TryParse(Console.ReadLine(), out roll) || roll < 1)
            {
                Console.WriteLine("please Enter valid RollNumber");
            }
            var value = StudentList<Student>.GetStudentByRollNo(roll);
            if (value == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Match Found");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value.Name);
                Console.WriteLine(value.Age);
                Console.WriteLine(value.RollNumber);
                Console.WriteLine(value.Grade);
            }
        }

        // The RemoveStudent method prompts the user to input a student's full name, age, roll number, and grade.
        // It validates the input and removes the corresponding Student object from the StudentList.
        public static void RemoveStudent()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please Input Student's Full Name");
            string name = Console.ReadLine();
            Console.WriteLine($"Please Input {name}'s Age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 100)
            {
                Console.WriteLine("please Enter valid Age");
            }
            Console.WriteLine($"Please Input {name}'s RollNumber");
            int roll;
            while (!int.TryParse(Console.ReadLine(), out roll) || roll < 1)
            {
                Console.WriteLine("please Enter valid RollNumber");
            }
            Console.WriteLine($"Please Input {name}'s Grade");
            float grade;
            while (!float.TryParse(Console.ReadLine(), out grade) || grade < 1f || grade > 4f)
            {
                Console.WriteLine("please Enter valid year");
            }

            StudentList<Student>.RemoveStudent(new Student(name, age, roll, grade));
        }

        // The Update method allows the user to update a specific attribute (name, age, or grade) of a student.
        // It prompts the user to select the attribute and the student to update, and then modifies
        // the selected attribute of the student.
        public static void Update()
        {
            int prompt;
            Console.WriteLine("press the corresponding number to Update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Grade");
            Console.Write(" ==> ");
            while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 3");
                Console.Write(" ==> ");
            }
        
            Console.WriteLine("press the corresponding Student number to Update");
            int count = StudentList<Student>.DisplayAll();
            int line;
            Console.Write(" Student Number ==> ");
            while (!int.TryParse(Console.ReadLine(), out line) || line < 1 || line > count)
            {
                Console.WriteLine($"Please Enter numbers between 1 and {count}");
                Console.Write(" ==> ");
            }
            StudentList<Student>.UpdateStudnentInfo(prompt, line);
        }
    }
}