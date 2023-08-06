using System.Xml;

namespace A2SVLearningPath_Day5_Task1.Class
{
    // The Student class represents a student and contains properties for their name, age, roll number, and grade.
    public class Student
    {
        // The Name property represents the name of the student and allows both read and write access.
        public string Name { get; set; }
        // The Age property represents the age of the student and allows both read and write access.
        public int Age { get; set; }

        // The RollNumber field represents the roll number of the student and is read-only.
        // Once set in the constructor, it cannot be modified.
        public readonly int RollNumber;

        // The Grade property represents the grade of the student and allows both read and write access.
        public float Grade { get; set; }

        // The constructor initializes the Student object with the provided name, age, roll number, and grade.
        public Student(string name, int age, int rollNumber, float grade)
        {
            Name = name;
            Age = age;
            RollNumber = rollNumber;
            Grade = grade;
        }
    }
}