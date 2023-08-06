using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace A2SVLearningPath_Day5_Task1.Class
{
    
    // The Console.ForegroundColor property is used to set the color of the console output for better readability.
    // Overall, this code provides a basic implementation for managing a list of students and performing various operations on it.
    
    // This code defines a generic class called StudentList<T> that manages a list of students.
    // The class provides methods to add, retrieve, remove, and update student information.
    public class StudentList<T>
    {
        // The student data is stored in a JSON file located at "../File/data.json".
        // The class uses the Newtonsoft.Json library for JSON serialization and deserialization.
        private const string Path = "../File/data.json";
        private static List<T> _students = new List<T>();

        // The private methods in the class are used for internal operations:
        // Reads the JSON file and updates the internal list of students.
        private static void UpdateList()
        {
            string jsonString = File.ReadAllText(Path);
            _students = JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        // Serializes the internal list of students to JSON and writes it to the file.
        private static void UpdateJson()
        {
            string jsonString = JsonConvert.SerializeObject(_students);
            File.WriteAllText(Path, jsonString);
            Console.WriteLine("Student data added and serialized to JSON successfully!");
        }
        
        // Adds a new student to the list and updates the JSON file.
        public static void AddStudent(T student)
        {
            UpdateList();
            _students.Add(student);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student added Successfully");
            UpdateJson();
        }

        // Retrieves a list of students with a matching name.
        public static IEnumerable<T> GetStudentByName(string name)
        {
            UpdateList();
            return _students.Where(stu => ((stu as Student)?.Name).Contains(name));
        }

        // Retrieves a student with a matching roll number.
        public static T GetStudentByRollNo(int rollNo)
        {
            UpdateList();
            return _students.FirstOrDefault(stu => (stu as Student)?.RollNumber == rollNo);
        }


        // Displays all the students in the list with their details.
        public static int DisplayAll()
        {
            UpdateList();
            int index = 1;
            foreach (var val in _students)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    XXXXXXXXXXXXXXXX Student {index} XXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Student Name: " + (val as Student)?.Name);
                Console.WriteLine("Student Age: " + (val as Student)?.Age);
                Console.WriteLine("Student Roll No: " + (val as Student)?.RollNumber);
                Console.WriteLine("Student Grade: " + (val as Student)?.Grade);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                index = index + 1;
            }

            return index - 1;
        }

        // Sorts the students in the list by name and displays them.
        public static void SortByName()
        {
            UpdateList();
            int index = 1;
            foreach (var val in _students.OrderBy(stu => (stu as Student)?.Name))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    XXXXXXXXXXXXXXXX Student {index} XXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Student Name: " + (val as Student)?.Name);
                Console.WriteLine("Student Age: " + (val as Student)?.Age);
                Console.WriteLine("Student Roll No: " + (val as Student)?.RollNumber);
                Console.WriteLine("Student Grade: " + (val as Student)?.Grade);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                index = index + 1;
            }
        }
        
        // Sorts the students in the list by age and displays them.
        public static void SortByAge()
        {
            UpdateList();
            int index = 1;
            foreach (var val in _students.OrderBy(stu => (stu as Student)?.Age))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    XXXXXXXXXXXXXXXX Student {index} XXXXXXXXXXXXXXXXXXXX");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Student Name: " + (val as Student)?.Name);
                Console.WriteLine("Student Age: " + (val as Student)?.Age);
                Console.WriteLine("Student Roll No: " + (val as Student)?.RollNumber);
                Console.WriteLine("Student Grade: " + (val as Student)?.Grade);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                index = index + 1;
            }
        }

        // Removes a student from the list and updates the JSON file.
        public static void RemoveStudent(T stud)
        {
            UpdateList();
            int index = 0;
            int length = _students.Count;
            foreach (T search in _students)
            {
                if ((search as Student)?.Name == (stud as Student)?.Name && (search as Student)?.RollNumber == (stud as Student)?.RollNumber)
                {
                    break;
                }

                index = index + 1;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (index == length)
            {
                Console.WriteLine("The Student does not exist");
            }
            else
            {
                _students.RemoveAt(index);
                Console.WriteLine("Student removed Successfully");
            }
            UpdateJson();
        }

        // Updates a specific student's information based on the prompt and line number.
        // Also Updates Json File
        public static void UpdateStudnentInfo(int prompt, int line)
        {
            UpdateList();
            if (_students[line - 1] is Student student)
            {
                switch (prompt)
                {
                    case 1:
                        Console.WriteLine("New Data: ");
                        student.Name = Console.ReadLine();;
                        break;
                    case 2:
                        int age = 1;
                        Console.Write(" Age ==> ");
                        if (!int.TryParse(Console.ReadLine(), out age) || age < 1)
                        {
                            Console.WriteLine($"Please Enter numbers between 1 and 100");
                            Console.Write(" ==> ");
                        }
                        student.Age = age;
                        break;
                    case 3:
                        float grade = 1;
                        Console.Write(" Grade ==> ");
                        if (!float.TryParse(Console.ReadLine(), out grade) || grade < 1)
                        {
                            Console.WriteLine($"Please Enter numbers between 1 and 4");
                            Console.Write(" ==> ");
                        }
                        student.Grade = grade;
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can not update Student Info");
            }
            UpdateJson();
        }

    }
}