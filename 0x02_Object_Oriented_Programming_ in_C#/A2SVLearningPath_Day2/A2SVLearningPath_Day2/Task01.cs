using System;

namespace A2SVLearningPath_Day2
{
    public class Task01
    {
        public static void PrintShapeArea(object obj)
        {
            if (obj is Shape shape)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Shape: " + shape.Name);
                Console.WriteLine("Area: " + shape.CalculateArea());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid object Type");
            }
        }
    }
}